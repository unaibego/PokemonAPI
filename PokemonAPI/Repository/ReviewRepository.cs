using PokemonAPI.Data;
using PokemonAPI.Dto;
using PokemonAPI.Interface;

namespace PokemonAPI.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DataContext _context;

        public ReviewRepository(DataContext context)
        {
            _context = context;
        }
        public ReviewDto GetReview(int reviewId)
        {
            return _context.Reviews.Where(p => p.Id == reviewId).Select(p => p.ToDto()).FirstOrDefault();
        }

        public ICollection<ReviewDto> GetReviews()
        {
            return _context.Reviews.Select(p => p.ToDto()).ToList();
        }

        public ICollection<ReviewDto> GetReviewsOfAPokemon(int pokeId)
        {
            // bere kodigoa
            return _context.Reviews.Where(r => r.Pokemon.Id == pokeId).Select(r => r.ToDto()).ToList();
            // nire kodigoa
            //return _context.Pokemons.Where(p => p.Id == pokeId).FirstOrDefault().Reviews.Select(p => p.ToDto()).ToList();
        }

        public bool ReviewExists(int reviewId)
        {
            return _context.Reviews.Any(p => p.Id == reviewId);
        }
    }
}
