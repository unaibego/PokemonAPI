using PokemonAPI.Data;
using PokemonAPI.Dto;
using PokemonAPI.Interface;
using PokemonAPI.Models;
using System.ComponentModel;

namespace PokemonAPI.Repository
{
    public class CategoryRepository: ICategoryRepository 
    {
        private DataContext _context;
        public CategoryRepository(DataContext context)
        {
            _context = context;
        }
        public bool CategoryExists(int Id)
        {
            return _context.Categories.Any(c => c.Id == Id);
        }

        public bool CreateCategory(Category category)
        {
            //var pokemon = _context.Pokemons.Where(p => p.Id == pokeId).FirstOrDefault();
            //var category = _context.Categories.Where(p => p.Id == categoryDto.Id).FirstOrDefault();

            //var pokemonCategoryEntity = new PokemonCategory
            //{
            //    PokemonId = pokeId,
            //    Pokemon = pokemon,
            //    CategoryId = category.Id,
            //    Category = category
            //};
            //_context.Add(pokemonCategoryEntity);
            //var categoryMapped = categoryDto.NotDto();
            _context.Add(category);
            return Save();
        }

        public ICollection<CategoryDto> GetCategories()
        {
            return _context.Categories.OrderBy(p => p.Id).Select(c => c.ToDto()).ToList();
        }
        public CategoryDto GetCategory(int Id)
        {
            //return _context.Categories.FirstOrDefault(c => c.Id == Id); Nire kodea
            return _context.Categories.Where(e => e.Id == Id).FirstOrDefault().ToDto();
        }
        public ICollection<PokemonDto> GetPokemonByCategory(int categoryId)
        {
            return _context.PokemonCategories.Where(p => p.CategoryId == categoryId).Select(c => c.Pokemon.ToDto()).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateCategory(Category category)
        {
            _context.Update(category);
            return Save();
        }
        public bool DeleteCategory(Category category)
        {
            var categoryToDetele = _context.Categories.Where(c => c.Id == category.Id).FirstOrDefault();
            _context.Remove(categoryToDetele);
            return Save();
        }
    }
}
