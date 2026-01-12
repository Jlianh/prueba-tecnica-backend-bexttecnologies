using BxtGeography.DTO;
using BxtGeography.Models;

namespace BxtGeography.Mapper
{
    public interface IDepartamentMapper
    {
        Departament SaveDtoToEntity(SaveDepartamentDTO dto);
        Departament DtoToEntity(DepartamentDTO dto);
        DepartamentDTO EntitytoDto(Departament departament);
        IEnumerable<DepartamentDTO> EntityToDtoList(IEnumerable<Departament> country);

    }
}
