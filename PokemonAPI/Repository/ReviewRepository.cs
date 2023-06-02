using PokemonAPI.Data;
using PokemonAPI.Dto;
using PokemonAPI.Interface;
using PokemonAPI.Models;

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
        public bool CreateReview(int reviewerId, int pokemonId, Review review)
        {
            var reviewer = _context.Reviewers.Where(p => p.Id == reviewerId).FirstOrDefault();
            var pokemon = _context.Pokemons.Where(p => p.Id == pokemonId).FirstOrDefault();
            review.Reviewer = reviewer;
            review.Pokemon = pokemon;
            _context.Add(review);
            return Save();
        }
        public bool UpdateReview(Review review) 
        {
            _context.Update(review);
            return Save();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
