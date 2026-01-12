using BxtGeography.DTO;
using BxtGeography.Models;

namespace BxtGeography.Mapper.Implement
{
    public class CountryMapper : ICountryMapper
    {
        public Country SaveDtoToEntity(SaveCountryDTO dto)
        {
            return new Country
            {
                Id = dto.id,
                Name = dto.name,
                Flag = dto.flag
            };
        }

        public Country DtoToEntity(CountryDTO dto)
        {
            return new Country
            {
                Id = dto.id,
                Name = dto.name,
                Flag = dto.flag,
                Departaments = dto.departaments.Select(d => new Departament
                {
                    Id = d.id,
                    Name = d.name,
                    Cities = d.city.Select(d => new City
                    {
                        Id = d.id,
                        Name = d.name,
                    }).ToList(),
                }).ToList(),
            };
        }

        public CountryDTO EntitytoDto(Country country)
        {
            return new CountryDTO
            {
                id = country.Id,
                name = country.Name,
                flag = country.Flag,
                departaments = country.Departaments.Select(d => new DepartamentDTO
                {
                    id = d.Id,
                    name = d.Name,
                    city = d.Cities.Select(d => new CityDTO
                    {
                        id = d.Id,
                        name = d.Name,
                    }).ToList(),
                }).ToList(),
            }
            ;
        }
        public IEnumerable<CountryDTO> EntityToDtoList(IEnumerable<Country> country)
        {
            return country.Select(country => EntitytoDto(country));
        }
    }
}
