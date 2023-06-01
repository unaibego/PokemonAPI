using PokemonAPI.Models;

namespace PokemonAPI.Dto
{
    public class ReviewerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Reviewer NotDto()
        {
            return new Reviewer
            {
                Id = Id,
                FirstName = FirstName,
                LastName = LastName,
            };
        }
    }
}
