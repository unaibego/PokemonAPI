using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Dto;
using PokemonAPI.Interface;

namespace PokemonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : Controller
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewController(IReviewRepository reviewRepository) 
        {
            _reviewRepository = reviewRepository;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ReviewDto>))]
        public IActionResult GetReviews()
        {
            var reviews = _reviewRepository.GetReviews();
            if (!ModelState.IsValid)
                return BadRequest();
            return Ok(reviews);
        }
        [HttpGet("{reviewId}")]
        [ProducesResponseType(200, Type = typeof(ReviewDto))]
        [ProducesResponseType(400)]
        public IActionResult GetReview(int reviewId)
        {
            if (!_reviewRepository.ReviewExists(reviewId))
                return NotFound();
            var review = _reviewRepository.GetReview(reviewId);
            if (!ModelState.IsValid)
                return BadRequest();
            return Ok(review);
        }
        [HttpGet("pokemon/{pokeId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ReviewDto>))]
        [ProducesResponseType(400)]

        public IActionResult GetReviewOfAPokemon(int pokeId)
        {
            var reviews = _reviewRepository.GetReviewsOfAPokemon(pokeId);
            if (!ModelState.IsValid)
                return BadRequest();
            return Ok(reviews);
        }
    }
}
