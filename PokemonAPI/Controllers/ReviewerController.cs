using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Dto;
using PokemonAPI.Interface;

namespace PokemonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewerController: Controller
    {
        private readonly IReviewerRepository _reviewerRepository;

        public ReviewerController(IReviewerRepository reviewerRepository) 
        {
            _reviewerRepository = reviewerRepository;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<ReviewerDto>))]
        public IActionResult GetReviewerers()
        {
            var reviewerers = _reviewerRepository.GetReviewers();
            if (!ModelState.IsValid)
                return BadRequest();
            return Ok(reviewerers);
        }
        [HttpGet("{reviewerId}")]
        [ProducesResponseType(200, Type = typeof(ReviewerDto))]
        [ProducesResponseType(400)]
        public IActionResult GetReviewer(int reviewerId)
        {
            if (!_reviewerRepository.ReviewerExists(reviewerId))
                return NotFound();
            var reviewer = _reviewerRepository.GetReviewer(reviewerId);
            if (!ModelState.IsValid)
                return BadRequest();
            return Ok(reviewer);

        }
        [HttpGet("{reviewerId}/reviews")]
        [ProducesResponseType(200,Type = typeof(IEnumerable<ReviewDto>))]
        [ProducesResponseType(400)]
        public IActionResult GetReviewsByReviewer(int reviewerId)
        {
            if (!_reviewerRepository.ReviewerExists(reviewerId))
                return NotFound();
            var reviews = _reviewerRepository.GetReviewsByReviewer(reviewerId);
            if (!ModelState.IsValid)
                return BadRequest();
            return Ok(reviews);
        }
    }
}