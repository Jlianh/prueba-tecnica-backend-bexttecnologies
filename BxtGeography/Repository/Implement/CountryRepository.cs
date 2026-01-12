using BxtGeography.Data;
using BxtGeography.DTO;
using BxtGeography.Models;
using Microsoft.EntityFrameworkCore;

namespace BxtGeography.Repository.Implement
{
    public class CountryRepository : ICountryRepository
    {
        private readonly AppDbContext _appDbContext;

        public CountryRepository(AppDbContext appDbContext) 
        { 
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Country>> GetCountries() 
        {
            return await _appDbContext.Countries
                .Include(c => c.Departaments)
                .ThenInclude(d => d.Cities).ToListAsync();
        }

        public async Task<Country> GetCountryById(int id) 
        {
            var result = await _appDbContext.Countries.Include(c => c.Departaments)
                .ThenInclude(d => d.Cities).Where(c => c.Id == id).FirstOrDefaultAsync(c => c.Id == id);

            return result;
        }

        public async Task<Country> AddCountriesAsync(Country country) 
        {
            await _appDbContext.Countries.AddAsync(country);
            
            await _appDbContext.SaveChangesAsync();

            return country;
        }

        public async Task UpdateCountriesAsync(Country country) 
        {
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteCountriesAsync(int id) 
        {
            var result = await _appDbContext.Countries.FindAsync(id);

            if(result != null)
            {
                _appDbContext.Countries.Remove(result);

                await _appDbContext.SaveChangesAsync();

                return true;
            } else
            {
                return false;
            }
                
        }   

    }
}
