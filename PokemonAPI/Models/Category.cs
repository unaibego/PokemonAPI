using PokemonAPI.Dto;

namespace PokemonAPI.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<PokemonCategory> PokemonCategories { get; set; }
        public CategoryDto ToDto()
        {
            return new CategoryDto
            {
                Id = Id,
                Name = Name
            };
        }
    }
    
}
