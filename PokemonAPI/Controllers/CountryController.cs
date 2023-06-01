using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Dto;
using PokemonAPI.Interface;
using PokemonAPI.Models;
using PokemonAPI.Repository;

namespace PokemonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController:Controller
    {
        private readonly ICountryRepository _countryRepository;

        public CountryController(ICountryRepository countryRepository) 
        {
            _countryRepository = countryRepository;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CountryDto>))]
        public IActionResult GetCountries()
        {
            var countries = _countryRepository.GetCountries();
            if (!ModelState.IsValid)
                return BadRequest();
            return Ok(countries);
        }
        [HttpGet("{countryId}")]
        [ProducesResponseType(200, Type = typeof(CountryDto))]
        //[ProducesResponseType(400)]
        public IActionResult GetCountry(int countryId)
        {
            if (!_countryRepository.CountryExist(countryId))
                return NotFound();
            var country = _countryRepository.GetCountry(countryId);
            if (!ModelState.IsValid)
                return BadRequest();
            return Ok(country);
        }
        [HttpGet("/owner/{ownerId}")]
        [ProducesResponseType(200, Type = typeof(CountryDto))]
        public IActionResult GetCountryByOwner(int ownerId)
        {
            var country = _countryRepository.GetCountryByOwner(ownerId);
            if (!ModelState.IsValid)
                return BadRequest();
            return Ok(country);
        }
        //[HttpGet("/country/{ownerId}")]
        //[ProducesResponseType(200,Type = typeof(IEnumerable<OwnerDto>))]
        //[ProducesResponseType(400)]
        //public IActionResult GetOwnerFromACountry(int ownerId)
        //{
        //    var owners = _countryRepository.GetOwnersFromACountry(ownerId);
        //    if (!ModelState.IsValid)
        //        return BadRequest();
        //    return Ok(owners);
        //}
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCountry([FromBody] CountryDto countryCreate)
        {
            if (countryCreate == null)
                return BadRequest(ModelState);
            //hemen  berak pasatzen digun category-a guk ditugunetan bilatzen dugu
            var category = _countryRepository.GetCountries()
                .Where(c => c.Name.Trim().ToUpper() == countryCreate.Name.TrimEnd().ToUpper()).FirstOrDefault();
            if (category != null)
            {
                ModelState.AddModelError("", "Category already exists");
                return StatusCode(422, ModelState);
            }
            var categoryMap = _countryRepository.CreateCountry(countryCreate.NotDto());
            if (!ModelState.IsValid)
                return BadRequest();
            return Ok(categoryMap);
        }

    }
}
