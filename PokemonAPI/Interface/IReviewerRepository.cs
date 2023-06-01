using PokemonAPI.Dto;

namespace PokemonAPI.Interface
{
    public interface IReviewerRepository
    {
        ICollection<ReviewerDto> GetReviewers();
        ReviewerDto GetReviewer(int reviewerId);
        ICollection<ReviewDto> GetReviewsByReviewer(int reviewerId);
        bool ReviewerExists(int reviewerId);
    }
}
