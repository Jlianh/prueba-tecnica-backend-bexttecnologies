using BxtGeography.DTO;
using BxtGeography.Mapper;
using BxtGeography.Models;
using BxtGeography.Repository;
using System.Diagnostics.Metrics;

namespace BxtGeography.Service.Implement
{
    public class DepartamentService : IDepartamentService
    {
        private readonly IDepartamentRepository _departamentRepository;
        private readonly IDepartamentMapper _departamentMapper;

        //funcion para gestionar departamentos

        public DepartamentService(IDepartamentRepository departamentRepository, IDepartamentMapper departamentMapper) 
        { 
            _departamentMapper = departamentMapper;
            _departamentRepository = departamentRepository;
            
        }

        public async Task<IEnumerable<DepartamentDTO>> GetAllDepartamentAsync()
        {
            IEnumerable<Departament> departaments = await _departamentRepository.GetDepartaments();

            return _departamentMapper.EntityToDtoList(departaments);
        }

        public async Task<DepartamentDTO> GetDepartamentByID(int id)
        {
            var departament = await _departamentRepository.GetDepartamentById(id);

            if (departament == null)
                return null;

            return _departamentMapper.EntitytoDto(departament);
        }
        public async Task<DepartamentDTO> AddDepartament(SaveDepartamentDTO saveDepartament)
        {
            var departament = _departamentMapper.SaveDtoToEntity(saveDepartament);

            await _departamentRepository.AddDepartamentAsync(departament);

            return _departamentMapper.EntitytoDto(departament);
        }

        public async Task<DepartamentDTO> EditDepartament(SaveDepartamentDTO saveDepartament, int id)
        {
            Departament result = await _departamentRepository.GetDepartamentById(id);

            if (result == null)
            {
                return null;
            }

            result.Name = saveDepartament.name;
            result.CountryId = saveDepartament.countryId;

            await _departamentRepository.UpdateDepartamentAsync(result);

            return _departamentMapper.EntitytoDto(result);
        }

        public async Task<bool> DeleteDepartament(int id)
        {
            var result = await _departamentRepository.DeleteDepartamentsAsync(id);

            return result;

        }

    }
}
