using AutoMapper;
using HotelListingAPI.Contracts;
using HotelListingAPI.Data;
using HotelListingAPI.Exceptions;
using HotelListingAPI.Models.Country;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelListingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CountriesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICountiesRepository _countiesRepository;
        private readonly ILogger<CountriesController> _logger;

        public CountriesController(IMapper mapper, ICountiesRepository countiesRepository, ILogger<CountriesController> logger)
        {
            this._mapper = mapper;
            this._countiesRepository = countiesRepository;
            this._logger = logger;
        }

        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCountryDto>>> Getcountries()
        {
            var countries = await _countiesRepository.GetAllAsync();
            var records = _mapper.Map<List<GetCountryDto>>(countries);

            //var countries = await _context.countries.ToListAsync();
            //var records = _mapper.Map<List<GetCountryDto>>(countries);
            return Ok(records);
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryDto>> GetCountry(int id)
        {

            var country = await _countiesRepository.GetDetails(id);
            if (country == null)
            {
                throw new NotFoundException(nameof(GetCountry), id);
                //_logger.LogWarning($"Record found in{nameof(GetCountry)} with Id:{id}");
                //return NotFound();
            }
            var countryDto = _mapper.Map<CountryDto>(country);

            return Ok(countryDto);
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutCountry(int id, UpdateCountryDto updateCountryDto)
        {
            if (id != updateCountryDto.Id)
            {
                return BadRequest("Invalid Record Id");
            }

            //_context.Entry(updateCountryDto).State = EntityState.Modified;
            var country = await _countiesRepository.GetAsync(id);
            if (country == null)
            {
                throw new NotFoundException(nameof(GetCountry), id);
            }
            _mapper.Map(updateCountryDto, country);

            try
            {
                await _countiesRepository.UpdateAsync(country);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CountryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Country>> PostCountry(CreateCountryDto createCountryDto)

        {

            var country = _mapper.Map<Country>(createCountryDto);
            await _countiesRepository.AddAsync(country);

            return CreatedAtAction("GetCountry", new { id = country.Id }, country);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var country = await _countiesRepository.GetAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            await _countiesRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> CountryExists(int id)
        {
            return await _countiesRepository.Exits(id);
        }
    }
}
