using PokemonAPI.Models;

namespace PokemonAPI.Dto
{
    public class OwnerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gym { get; set; }
        public Owner NotDto()
        {
            return new Owner
            {
                Id = Id,
                FirstName = FirstName,
                LastName = LastName,
                Gym = Gym,

            };
        }
    }
}
