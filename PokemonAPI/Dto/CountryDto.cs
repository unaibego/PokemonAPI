using PokemonAPI.Models;

namespace PokemonAPI.Dto
{
    public class CountryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Country NotDto()
        {
            return new Country
            {
                Id = Id,
                Name = Name,
            };
        }
    }
}
