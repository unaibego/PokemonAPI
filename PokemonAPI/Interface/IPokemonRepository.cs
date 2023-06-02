using PokemonAPI.Dto;
using PokemonAPI.Models;

namespace PokemonAPI.Interface
{
    public interface IPokemonRepository
    {
        ICollection<PokemonDto> GetPokemons();
        PokemonDto GetPokemon(int id);
        PokemonDto GetPokemon(string name);
        decimal GetPokemonRating(int pokeId);
        bool PokemonExists(int pokeId);
        bool CreatePokemon(int categoryId, int ownerId, Pokemon pokemon);
        bool UpdatePokemon(int categoryId, int ownerId, Pokemon pokemon);
        bool Save();
    }
}
