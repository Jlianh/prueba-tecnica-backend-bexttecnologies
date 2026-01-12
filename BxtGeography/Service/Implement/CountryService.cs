using BxtGeography.DTO;
using BxtGeography.Mapper;
using BxtGeography.Models;
using BxtGeography.Repository;

namespace BxtGeography.Service.Implement
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly ICountryMapper _countryMapper;

        public CountryService(ICountryRepository countryRepository, ICountryMapper countryMapper) 
        { 
            _countryRepository = countryRepository;
            _countryMapper = countryMapper;
        }

        public async Task<IEnumerable<CountryDTO>> GetAllCountriesAsync()
        {
            IEnumerable<Country> countries = await _countryRepository.GetCountries();

            return _countryMapper.EntityToDtoList(countries);
        }

        public async Task<CountryDTO> GetCountryById(int id)
        {
            var country = await _countryRepository.GetCountryById(id);

            if (country == null)
                return null;

            return _countryMapper.EntitytoDto(country);
        }
        public async Task<CountryDTO> AddCountry(SaveCountryDTO saveCountry)
        {
            var country = _countryMapper.SaveDtoToEntity(saveCountry);

            await _countryRepository.AddCountriesAsync(country);

            return _countryMapper.EntitytoDto(country);
        }

        public async Task<CountryDTO> EditCountry(SaveCountryDTO saveCountry, int id)
        {
            Country result = await _countryRepository.GetCountryById(id);

            if (result == null)
            {
                return null;
            }

            result.Name = saveCountry.name;
            result.Flag = saveCountry.flag;

            await _countryRepository.UpdateCountriesAsync(result);

            return _countryMapper.EntitytoDto(result);
        }

        public async Task<bool> DeleteCountry(int id)
        {
            var result = await _countryRepository.DeleteCountriesAsync(id);

            return result;

        }

    }
}
