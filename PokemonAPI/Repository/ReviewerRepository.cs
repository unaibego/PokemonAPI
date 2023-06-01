using Microsoft.EntityFrameworkCore;
using PokemonAPI.Data;
using PokemonAPI.Dto;
using PokemonAPI.Interface;

namespace PokemonAPI.Repository
{
    public class ReviewerRepository :IReviewerRepository
    {
        private readonly DataContext _context;

        public ReviewerRepository(DataContext context)
        {
            _context = context;
        }

        public ReviewerDto GetReviewer(int reviewerId)
        {
            // include horrekin Reviewer eta reviews taulak batera itzuliko ditu (erlazionatuta egon behar dira):
            return _context.Reviewers.Where(p => p.Id == reviewerId).Include(p => p.Reviews).FirstOrDefault().ToDto();
        }

        public ICollection<ReviewerDto> GetReviewers()
        {
            return _context.Reviewers.OrderBy(p => p.Id).Select(p => p.ToDto()).ToList();
        }

        public ICollection<ReviewDto> GetReviewsByReviewer(int reviewerId)
        {
            return _context.Reviews.Where(p => p.Reviewer.Id == reviewerId).Select(p=> p.ToDto()).ToList(); 
            //return _context.Reviewers.Where(p => p.Id == reviewerId).Select(p => p.Reviews.Select(p => p.ToDto())).ToList();
            //throw new NotImplementedException();
        }

        public bool ReviewerExists(int reviewerId)
        {
            return _context.Reviewers.Any(p => p.Id == reviewerId);
        }
    }
}
