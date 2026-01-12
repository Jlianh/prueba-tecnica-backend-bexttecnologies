using BxtGeography.Models;

namespace BxtGeography.Repository
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> GetCountries();
        Task<Country> GetCountryById(int id);
        Task<Country> AddCountriesAsync(Country country);
        Task UpdateCountriesAsync(Country country);
        Task<bool> DeleteCountriesAsync(int id);


    }
}
