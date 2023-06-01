using PokemonAPI.Data;
using PokemonAPI.Dto;
using PokemonAPI.Interface;
using PokemonAPI.Models;

namespace PokemonAPI.Repository
{
    public class OwnerRepository: IOwnerRepository
    {
        private readonly DataContext _context;

        public OwnerRepository(DataContext context) 
        {
            _context = context;
        }

        public OwnerDto GetOwner(int ownerId)
        {
            return _context.Owners.Where(c => c.Id == ownerId).FirstOrDefault().ToDto(); 
        }

        public ICollection<OwnerDto> GetOwnerOfAPokemon(int pokeId)
        {
            return _context.PokemonOwners.Where(p => p.PokemonId == pokeId).Select(p => p.Owner.ToDto()).ToList();
            //return _context.Pokemons.Where(c => c.Id == pokeId).Select(c => c.PokemonOwners).Select(c => c.).ToList();
        }

        public ICollection<OwnerDto> GetOwners()
        {
            return _context.Owners.OrderBy(c => c.Id).Select(c => c.ToDto()).ToList();
        }

        public ICollection<PokemonDto> GetPokemonByOwner(int OwnerId)
        {
            return _context.PokemonOwners.Where(p => p.OwnerId == OwnerId).Select(p => p.Pokemon.ToDto()).ToList();
        }

        public bool OwnerExist(int ownerId)
        {
            return _context.Owners.Any(c => c.Id == ownerId);
        }
        public bool CreateOwner(int countryId, Owner owner)
        {
            var country = _context.Countries.Where(p => p.Id == countryId).FirstOrDefault();
            owner.Country = country;
            _context.Add(owner);
            return Save();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

    }
}
