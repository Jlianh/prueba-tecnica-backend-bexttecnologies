using BxtGeography.DTO;

namespace BxtGeography.Service
{
    public interface ICityService
    {
        Task<IEnumerable<CityDTO>> GetAllCitiesAsync();
        Task<CityDTO> GetCityByID(int id);
        Task<CityDTO> AddCity(SaveCityDTO saveCityDTO);
        Task<CityDTO> EditCity(SaveCityDTO saveCityDTO, int id);
        Task<bool> DeleteDepartament(int id);

    }
}
