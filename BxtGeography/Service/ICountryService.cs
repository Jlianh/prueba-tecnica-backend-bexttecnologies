using BxtGeography.DTO;

namespace BxtGeography.Service
{
    public interface ICountryService
    {
        Task<IEnumerable<CountryDTO>> GetAllCountriesAsync();
        Task<CountryDTO> GetCountryById(int id);
        Task<CountryDTO> AddCountry(SaveCountryDTO saveCountry);
        Task<CountryDTO> EditCountry(SaveCountryDTO saveCountry, int id);
        Task<bool> DeleteCountry(int id);

    }
}
