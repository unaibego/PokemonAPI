using PokemonAPI.Dto;
using PokemonAPI.Models;

namespace PokemonAPI.Interface
{
    public interface IReviewRepository
    {
        ICollection<ReviewDto> GetReviews();
        ReviewDto GetReview(int reviewId);
        ICollection<ReviewDto> GetReviewsOfAPokemon(int pokeId);
        bool ReviewExists(int reviewId);
        bool CreateReview(int reviewerId, int pokemonId, Review review);
        bool UpdateReview(Review review);
        bool Save();
    }
}

