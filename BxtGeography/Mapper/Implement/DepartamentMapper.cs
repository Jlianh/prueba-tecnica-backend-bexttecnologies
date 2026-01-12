using BxtGeography.DTO;
using BxtGeography.Models;

namespace BxtGeography.Mapper.Implement
{
    public class DepartamentMapper : IDepartamentMapper
    {
        public Departament SaveDtoToEntity(SaveDepartamentDTO dto)
        {
            return new Departament
            {
                Id = dto.id,
                Name = dto.name,
                CountryId = dto.countryId
            };
        }

        public Departament DtoToEntity(DepartamentDTO dto)
        {
            return new Departament
            {
                Id = dto.id,
                Name = dto.name,
                Cities = dto.city.Select(d => new City
                {
                    Id = d.id,
                    Name = d.name,
                }).ToList(),
            };
        }

        public DepartamentDTO EntitytoDto(Departament departament)
        {
            return new DepartamentDTO
            {
                    id = departament.Id,
                    name = departament.Name,
                    countryName = departament.Country?.Name,
                    countryId = departament.CountryId,
                    city = departament.Cities.Select(d => new CityDTO
                    {
                        id = d.Id,
                        name = d.Name,
                        departamentId = d.DepartamentId,
                        departament = d.Departament?.Name
                    }).ToList(),
            };
            
        }
        public IEnumerable<DepartamentDTO> EntityToDtoList(IEnumerable<Departament> departaments)
        {
            return departaments.Select(departaments => EntitytoDto(departaments));
        }
    }
}
