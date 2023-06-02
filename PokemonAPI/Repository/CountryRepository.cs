using Microsoft.EntityFrameworkCore.Diagnostics;
using PokemonAPI.Data;
using PokemonAPI.Dto;
using PokemonAPI.Interface;
using PokemonAPI.Models;

namespace PokemonAPI.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private DataContext _context;
        public CountryRepository(DataContext context)
        {
            _context = context;
            
        }
        public bool CountryExist(int countryId)
        {
            return _context.Countries.Any(c => c.Id == countryId);
        }

        public ICollection<CountryDto> GetCountries()
        {
            return _context.Countries.OrderBy(c => c.Id).Select(c => c.ToDto()).ToList();
        }

        public CountryDto GetCountry(int id)
        {
            return _context.Countries.Where(c => c.Id == id).FirstOrDefault().ToDto();
        }

        public CountryDto GetCountryByOwner(int ownerId)
        {
            return _context.Owners.Where(c => c.Id == ownerId).Select(c => c.Country.ToDto()).FirstOrDefault();
        }

        public ICollection<OwnerDto> GetOwnersFromACountry(int countryId)
        {
            return _context.Owners.Where(c => c.Country.Id == countryId).Select(c => c.ToDto()).ToList();
            throw new NotImplementedException();
        }
        public bool CreateCountry(Country country)
        {
            _context.Add(country);
            return Save();
        }
        public bool UpdateCountry(Country country)
        {
            _context.Update(country);
            return Save();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
