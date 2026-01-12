using BxtGeography.DTO;
using BxtGeography.Responses;
using BxtGeography.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BxtGeography.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<CityDTO>>>> GetAll() {
            var cites = await _cityService.GetAllCitiesAsync();
            return Ok(ApiResponse<IEnumerable<CityDTO>>.Ok(cites, "Cities Found"));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<CityDTO>>> GetById(int id)
        {
            var city = await _cityService.GetCityByID(id);
            if (city == null) return NotFound(ApiResponse<CityDTO>.Fail("City not found", 404));
            return Ok(ApiResponse<CityDTO>.Ok(city, "City Found"));
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<CityDTO>>> Create(SaveCityDTO saveCityDTO)
        {
            var city = await _cityService.AddCity(saveCityDTO);
            return CreatedAtAction(nameof(GetById), new { id = city.id }, ApiResponse<CityDTO>.Ok(city, "City Created"));
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<CityDTO>>> Update(SaveCityDTO saveCityDTO, int id)
        {
            var city = await _cityService.EditCity(saveCityDTO, id);
            if (city == null)
            {
                return BadRequest(ApiResponse<CityDTO>.Fail("The City wasnt updated", 404));
            }
            return Ok(ApiResponse<CityDTO>.Ok(city, "City Updated"));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<bool>>> Delete(int id)
        {
            try
            {
                var request = await _cityService.DeleteDepartament(id);
                if (request != true)
                {
                    return NotFound(ApiResponse<bool>.Fail("The City wasnt found", 404));
                }
                return Ok(ApiResponse<bool>.Ok(true, "City Deleted"));
            }
            catch (Exception ex) 
            {
                return ApiResponse<bool>.Fail(ex.ToString(), 400);
            }
            
        }
    }
}
