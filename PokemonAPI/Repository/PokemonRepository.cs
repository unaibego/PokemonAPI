using PokemonAPI.Data;
using PokemonAPI.Dto;
using PokemonAPI.Interface;
using PokemonAPI.Models;

namespace PokemonAPI.Repository
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly DataContext _context;
        public PokemonRepository(DataContext context) 
        {
            _context = context;
        }

        public PokemonDto GetPokemon(int id)
        {
            return _context.Pokemons.Where(p => p.Id == id).FirstOrDefault().ToDto();
        }

        public PokemonDto GetPokemon(string name)
        {
            return _context.Pokemons.Where(p => p.Name == name).FirstOrDefault().ToDto();

        }

        public decimal GetPokemonRating(int pokeId)
        {
            var review =  _context.Reviews.Where(p => p.Pokemon.Id == pokeId);
            if (review.Count() <= 0)
                return 0;
            return ((decimal)review.Sum(r=> r.Rating)/ review.Count());
        }

        public ICollection<Pokemon> GetPokemons()
        {
            return _context.Pokemons.OrderBy(p=> p.Id).ToList();
        }

        public bool PokemonExists(int pokeId)
        {
            return _context.Pokemons.Any(p  => p.Id == pokeId);
        }
    }
}
