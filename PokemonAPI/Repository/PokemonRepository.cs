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

        public ICollection<PokemonDto> GetPokemons()
        {
            return _context.Pokemons.OrderBy(p=> p.Id).Select(c => c.ToDto()).ToList();
        }

        public bool PokemonExists(int pokeId)
        {
            return _context.Pokemons.Any(p  => p.Id == pokeId);
        }
        public bool CreatePokemon(int categoryId, int ownerId, Pokemon pokemon)
        {
            var category = _context.Categories.Where(p => p.Id == categoryId).FirstOrDefault();
            var owner = _context.Owners.Where(p => p.Id ==  ownerId).FirstOrDefault();
            var pokemonCategoryEntity = new PokemonCategory
            {
                Category = category,
                Pokemon = pokemon
            };
            _context.Add(pokemonCategoryEntity);
            var pokemonOwnerEntity = new PokemonOwner
            {
                Owner = owner,
                Pokemon = pokemon
            };
            _context.Add(pokemonOwnerEntity);
            _context.Add(pokemon);
            return Save();
        }
        public bool UpdatePokemon(int ownerId, int categoryId, Pokemon pokemon)
        {
            var owner = _context.Owners.Where(p => p.Id == ownerId).FirstOrDefault();
            var category = _context.Categories.Where(p => p.Id == categoryId).FirstOrDefault();
            var pokemonCategoryEntity = _context.PokemonCategories.Where(p => p.PokemonId == pokemon.Id).FirstOrDefault();
            var pokemonOwnerEntity = _context.PokemonOwners.Where(p => p.PokemonId == pokemon.Id).FirstOrDefault();
            _context.Remove(pokemonCategoryEntity);
            _context.Remove(pokemonOwnerEntity);

            var newPokemonCategoryEntity = new PokemonCategory
            {
                Category = category,
                Pokemon = pokemon
            };
            var newPokemonOwnerEntity = new PokemonOwner
            {
                Owner = owner,
                Pokemon = pokemon
            };
            _context.Add(newPokemonCategoryEntity);
            _context.Add(newPokemonOwnerEntity);
            _context.Update(pokemon);
            return Save();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
