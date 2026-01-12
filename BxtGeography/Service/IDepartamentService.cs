using BxtGeography.DTO;

namespace BxtGeography.Service
{
    public interface IDepartamentService
    {
        Task<IEnumerable<DepartamentDTO>> GetAllDepartamentAsync();
        Task<DepartamentDTO> GetDepartamentByID(int id);
        Task<DepartamentDTO> AddDepartament(SaveDepartamentDTO saveDepartament);
        Task<DepartamentDTO> EditDepartament(SaveDepartamentDTO saveDepartament, int id);
        Task<bool> DeleteDepartament(int id);

    }
}
