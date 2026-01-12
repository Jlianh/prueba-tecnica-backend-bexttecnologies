using BxtGeography.Data;
using BxtGeography.DTO;
using BxtGeography.Models;
using Microsoft.EntityFrameworkCore;

namespace BxtGeography.Repository.Implement
{
    public class DepartamentRepository : IDepartamentRepository
    {
        private readonly AppDbContext _appDbContext;

        public DepartamentRepository(AppDbContext appDbContext) 
        { 
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Departament>> GetDepartaments() 
        {
            return await _appDbContext.Departaments
                .Include(c => c.Country)
                .Include(c => c.Cities).ToListAsync();
        }

        public async Task<Departament> GetDepartamentById(int id) 
        {
            var result = await _appDbContext.Departaments.Include(c => c.Cities)
                .FirstOrDefaultAsync(c => c.Id == id);

            return result;
        }

        public async Task<Departament> AddDepartamentAsync(Departament departament)
        {
            await _appDbContext.Departaments.AddAsync(departament);
            
            await _appDbContext.SaveChangesAsync();

            return departament;
        }

        public async Task UpdateDepartamentAsync(Departament departament) 
        {
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteDepartamentsAsync(int id) 
        {
            var result = await _appDbContext.Departaments.FindAsync(id);

            if(result != null)
            {
                _appDbContext.Departaments.Remove(result);

                await _appDbContext.SaveChangesAsync();

                return true;
            } else
            {
                return false;
            }
                
        }   

    }
}
