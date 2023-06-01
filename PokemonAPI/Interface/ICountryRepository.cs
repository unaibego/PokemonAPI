using PokemonAPI.Dto;
using PokemonAPI.Models;

namespace PokemonAPI.Interface
{
    public interface ICountryRepository
    {
        ICollection<CountryDto> GetCountries();
        CountryDto GetCountry(int id);
        CountryDto GetCountryByOwner(int ownerId);
        ICollection<OwnerDto> GetOwnersFromACountry(int countryId);
        bool CountryExist(int countryId);
        bool CreateCountry(Country country);
        bool Save();
    }
}
