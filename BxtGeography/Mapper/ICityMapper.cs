using BxtGeography.DTO;
using BxtGeography.Models;

namespace BxtGeography.Mapper
{
    public interface ICityMapper
    {
        City SaveDtoToEntity(SaveCityDTO dto);
        City DtoToEntity(CityDTO dto);
        CityDTO EntitytoDto(City city);
        IEnumerable<CityDTO> EntityToDtoList(IEnumerable<City> city);

    }
}
