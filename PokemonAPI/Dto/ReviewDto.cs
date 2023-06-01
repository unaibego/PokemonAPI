using PokemonAPI.Models;

namespace PokemonAPI.Dto
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
        public Review NotDto()
        {
            return new Review
            {
                Id = Id,
                Title = Title,
                Text = Text,
                Rating = Rating,
            };
        }
    }

}
