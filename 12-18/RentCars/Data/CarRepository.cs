using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace RentCars
{
    public class CarRepository : GenericRepository<Car>
    {
        public CarRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Car>> GetAvailableCarsAsync()
        {
            return await _dbSet.Where(c => c.Status == true).ToListAsync();
        }

        public async Task<List<Car>> GetCarsByClassAsync(string carClass)
        {
            return await _dbSet.Where(c => c.Class == carClass).ToListAsync();
        }
    }
}