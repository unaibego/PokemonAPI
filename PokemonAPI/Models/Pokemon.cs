using PokemonAPI.Dto;

namespace PokemonAPI.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<PokemonCategory> PokemonCategories { get; set; }
        public ICollection<PokemonOwner> PokemonOwners { get; set;}
        public PokemonDto ToDto()
        {
            return new PokemonDto
            {
                Id = Id, //hemen null sartu ezkero igual errorea ematen du
                Name = Name,
                BirthDate = BirthDate
            };
        }
    }
}
