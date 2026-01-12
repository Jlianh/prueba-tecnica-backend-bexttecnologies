using BxtGeography.Models;

namespace BxtGeography.Repository
{
    public interface IDepartamentRepository
    {
        Task<IEnumerable<Departament>> GetDepartaments();
        Task<Departament> GetDepartamentById(int id);
        Task<Departament> AddDepartamentAsync(Departament departament);
        Task UpdateDepartamentAsync(Departament departament);
        Task<bool> DeleteDepartamentsAsync(int id);


    }
}
