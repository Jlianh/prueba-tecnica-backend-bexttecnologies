using BxtGeography.DTO;
using BxtGeography.Models;

namespace BxtGeography.Mapper.Implement
{
    public class CityMapper : ICityMapper
    {
        public City SaveDtoToEntity(SaveCityDTO dto)
        {
            return new City
            {
                Id = dto.id,
                Name = dto.name,
                DepartamentId = dto.departamentId
            };
        }

        public City DtoToEntity(CityDTO dto)
        {
            return new City
            {
                Id = dto.id,
                Name = dto.name,
                DepartamentId = dto.departamentId
            };
        }

        public CityDTO EntitytoDto(City city)
        {
            return new CityDTO
            {
                id = city.Id,
                name = city.Name,
                departamentId = city.DepartamentId,
                departament = city.Departament.Name
            };
            
        }
        public IEnumerable<CityDTO> EntityToDtoList(IEnumerable<City> city)
        {
            return city.Select(city => EntitytoDto(city));
        }
    }
}
