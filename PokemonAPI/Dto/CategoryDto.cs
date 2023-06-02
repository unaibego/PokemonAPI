using PokemonAPI.Models;

namespace PokemonAPI.Dto
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category NotDto()
        {
            return new Category()
            {
                Id = Id,
                Name = Name,
            };
        }
    }
}
