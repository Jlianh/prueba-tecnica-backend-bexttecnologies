using BxtGeography.Models;

namespace BxtGeography.Repository
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> GetCities();
        Task<City> GetCityById(int id);
        Task<City> AddCitytAsync(City city);
        Task UpdateCityAsync(City city);
        Task<bool> DeleteCityAsync(int id);


    }
}
