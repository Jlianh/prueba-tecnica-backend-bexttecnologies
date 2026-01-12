using BxtGeography.DTO;
using BxtGeography.Models;

namespace BxtGeography.Mapper
{
    public interface ICountryMapper
    {
        Country SaveDtoToEntity(SaveCountryDTO dto);
        Country DtoToEntity(CountryDTO dto);
        CountryDTO EntitytoDto(Country country);
        IEnumerable<CountryDTO> EntityToDtoList(IEnumerable<Country> countries);

    }
}
