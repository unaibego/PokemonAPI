using PokemonAPI.Dto;
using PokemonAPI.Models;

namespace PokemonAPI.Interface
{
    public interface ICategoryRepository
    {
        ICollection<CategoryDto> GetCategories();
        CategoryDto GetCategory(int id);
        ICollection<PokemonDto> GetPokemonByCategory(int categoryId);
        bool CategoryExists(int id);
        bool CreateCategory(Category category);
        bool UpdateCategory(Category category);
        bool DeleteCategory(Category category);
        bool Save();
    }
}
