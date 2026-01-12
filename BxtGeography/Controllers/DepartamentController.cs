using BxtGeography.DTO;
using BxtGeography.Responses;
using BxtGeography.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BxtGeography.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class DepartamentController : ControllerBase
    {
        private readonly IDepartamentService _departamentService;

        public DepartamentController(IDepartamentService departamentService)
        {
            _departamentService = departamentService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<DepartamentDTO>>>> GetAll() {
            var departaments = await _departamentService.GetAllDepartamentAsync();
            return Ok(ApiResponse<IEnumerable<DepartamentDTO>>.Ok(departaments, "Departaments Found"));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<DepartamentDTO>>> GetById(int id)
        {
            var departament = await _departamentService.GetDepartamentByID(id);
            if (departament == null) return NotFound(ApiResponse<DepartamentDTO>.Fail("Departament not found", 404));
            return Ok(ApiResponse<DepartamentDTO>.Ok(departament, "Departament Found"));
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<DepartamentDTO>>> Create(SaveDepartamentDTO saveDepartamentDTO)
        {
            var departament = await _departamentService.AddDepartament(saveDepartamentDTO);
            return CreatedAtAction(nameof(GetById), new { id = departament.id }, ApiResponse<DepartamentDTO>.Ok(departament, "Departament Created"));
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<DepartamentDTO>>> Update(SaveDepartamentDTO saveDepartamentDTO, int id)
        {
            var country = await _departamentService.EditDepartament(saveDepartamentDTO, id);
            if (country == null)
            {
                return BadRequest(ApiResponse<DepartamentDTO>.Fail("The departament wasnt updated", 404));
            }
            return Ok(ApiResponse<DepartamentDTO>.Ok(country, "Departament Updated"));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<bool>>> Delete(int id)
        {
            try
            {
                var request = await _departamentService.DeleteDepartament(id);
                if (request != true)
                {
                    return NotFound(ApiResponse<bool>.Fail("The departament wasnt found", 404));
                }
                return Ok(ApiResponse<bool>.Ok(true, "Departament Deleted"));
            } catch (DbUpdateException ex)
            {
                return ApiResponse<bool>.Fail("Cannot delete departament because it has Cities assigned", 409);
            }
            
        }
    }
}
