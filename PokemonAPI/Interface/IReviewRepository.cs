using PokemonAPI.Dto;

namespace PokemonAPI.Interface
{
    public interface IReviewRepository
    {
        ICollection<ReviewDto> GetReviews();
        ReviewDto GetReview(int reviewId);
        ICollection<ReviewDto> GetReviewsOfAPokemon(int pokeId);
        bool ReviewExists(int reviewId);
    }
}

