using PokemonAPI.Dto;
using PokemonAPI.Models;

namespace PokemonAPI.Interface
{
    public interface IReviewerRepository
    {
        ICollection<ReviewerDto> GetReviewers();
        ReviewerDto GetReviewer(int reviewerId);
        ICollection<ReviewDto> GetReviewsByReviewer(int reviewerId);
        bool ReviewerExists(int reviewerId);
        bool CreateReviewer(Reviewer reviewer);
        bool UpdateReviewer(Reviewer reviewer);
        bool Save();
    }
}
