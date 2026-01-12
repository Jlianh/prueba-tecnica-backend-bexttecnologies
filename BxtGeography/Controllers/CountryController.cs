using BxtGeography.DTO;
using BxtGeography.Responses;
using BxtGeography.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BxtGeography.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<CountryDTO>>>> GetAllCountries() { 
            var countries = await _countryService.GetAllCountriesAsync();
            return Ok(ApiResponse<IEnumerable<CountryDTO>>.Ok(countries, "Countries Found"));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<CountryDTO>>> GetById(int id)
        {
            var country = await _countryService.GetCountryById(id);
            if (country == null) return NotFound(ApiResponse<CountryDTO>.Fail("Country not found", 404));
            return Ok(ApiResponse<CountryDTO>.Ok(country, "Country Found"));
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<CountryDTO>>> Create(SaveCountryDTO saveCountryDTO)
        {
            var country = await _countryService.AddCountry(saveCountryDTO);
            return CreatedAtAction(nameof(GetById), new { id = country.id }, ApiResponse<CountryDTO>.Ok(country, "Country Created"));
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<CountryDTO>>> Update(SaveCountryDTO saveCountryDTO, int id)
        {
            var country = await _countryService.EditCountry(saveCountryDTO, id);
            if (country == null)
            {
                return BadRequest(ApiResponse<CountryDTO>.Fail("The country wasnt updated", 404));
            }
            return Ok(ApiResponse<CountryDTO>.Ok(country, "Country Updated"));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<bool>>> Delete(int id)
        {
            try
            {
                var request = await _countryService.DeleteCountry(id);
                if (request != true)
                {
                    return NotFound(ApiResponse<bool>.Fail("The country wasnt found", 404));
                }
                return Ok(ApiResponse<bool>.Ok(true, "Country Deleted"));
            }
            catch (DbUpdateException ex) 
            {
                return ApiResponse<bool>.Fail("Cannot delete departament because it has Departaments assigned", 409);
            }
            
        }
    }
}
