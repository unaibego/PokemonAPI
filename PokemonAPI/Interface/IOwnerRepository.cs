using PokemonAPI.Dto;
using PokemonAPI.Models;
using System.Reflection;

namespace PokemonAPI.Interface
{
    public interface IOwnerRepository
    {
        ICollection<OwnerDto> GetOwners();
        OwnerDto GetOwner(int ownerId);
        ICollection<OwnerDto> GetOwnerOfAPokemon(int pokeId);
        ICollection<PokemonDto> GetPokemonByOwner(int OwnerId);
        bool OwnerExist(int ownerId);
        bool CreateOwner(int countryId,Owner owner);
        bool Save();
    }
}