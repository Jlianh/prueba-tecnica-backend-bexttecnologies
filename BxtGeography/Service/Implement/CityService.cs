using BxtGeography.DTO;
using BxtGeography.Mapper;
using BxtGeography.Models;
using BxtGeography.Repository;

namespace BxtGeography.Service.Implement
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly ICityMapper _cityMapper;
        

        public CityService(ICityRepository cityRepository, ICityMapper cityMapper) 
        { 
            _cityMapper = cityMapper;
            _cityRepository = cityRepository;
            
        }

        public async Task<IEnumerable<CityDTO>> GetAllCitiesAsync()
        {
            IEnumerable<City> city = await _cityRepository.GetCities();

            return _cityMapper.EntityToDtoList(city);
        }

        public async Task<CityDTO> GetCityByID(int id)
        {
            var city = await _cityRepository.GetCityById(id);

            if (city == null)
                return null;

            return _cityMapper.EntitytoDto(city);
        }
        public async Task<CityDTO> AddCity(SaveCityDTO saveCityDTO)
        {
            var city = _cityMapper.SaveDtoToEntity(saveCityDTO);

            await _cityRepository.AddCitytAsync(city);

            return _cityMapper.EntitytoDto(city);
        }

        public async Task<CityDTO> EditCity(SaveCityDTO saveCityDTO, int id)
        {
            City result = await _cityRepository.GetCityById(id);

            if (result == null)
            {
                return null;
            }

            result.Name = saveCityDTO.name;
            result.DepartamentId = saveCityDTO.departamentId;

            await _cityRepository.UpdateCityAsync(result);

            return _cityMapper.EntitytoDto(result);
        }

        public async Task<bool> DeleteDepartament(int id)
        {
            var result = await _cityRepository.DeleteCityAsync(id);

            return result;

        }

    }
}
