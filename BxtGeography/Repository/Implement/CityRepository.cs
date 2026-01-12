using BxtGeography.Data;
using BxtGeography.DTO;
using BxtGeography.Models;
using Microsoft.EntityFrameworkCore;

namespace BxtGeography.Repository.Implement
{
    public class CityRepository : ICityRepository
    {
        private readonly AppDbContext _appDbContext;

        public CityRepository(AppDbContext appDbContext) 
        { 
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<City>> GetCities() 
        {
            return await _appDbContext.Cities.Include(d => d.Departament).ToListAsync();
        }

        public async Task<City> GetCityById(int id) 
        {
            var result = await _appDbContext.Cities.Include(d => d.Departament)
                .FirstOrDefaultAsync(c => c.Id == id);

            return result;
        }

        public async Task<City> AddCitytAsync(City city)
        {
            await _appDbContext.Cities.AddAsync(city);
            
            await _appDbContext.SaveChangesAsync();

            return await _appDbContext.Cities.Include(d => d.Departament).FirstAsync(c => c.Id == city.Id);
        }

        public async Task UpdateCityAsync(City city) 
        {
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteCityAsync(int id) 
        {
            var result = await _appDbContext.Cities.FindAsync(id);

            if(result != null)
            {
                _appDbContext.Cities.Remove(result);

                await _appDbContext.SaveChangesAsync();

                return true;
            } else
            {
                return false;
            }
                
        }   

    }
}
