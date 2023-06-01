using PokemonAPI.Dto;

namespace PokemonAPI.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Owner> Owners { get; set; }
        public CountryDto ToDto()
        {
            return new CountryDto
            {
                Id = Id,
                Name = Name,
            };
        }

    }
}
