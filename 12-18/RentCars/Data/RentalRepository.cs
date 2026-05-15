using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace RentCars
{
    public class RentalRepository : GenericRepository<RentalModel>
    {
        public RentalRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<RentalModel>> GetActiveRentalsAsync()
        {
            return await _dbSet.Where(r => r.IsActive == true).ToListAsync();
        }

        public async Task<List<RentalModel>> GetRentalsByCustomerAsync(string customerName)
        {
            return await _dbSet.Where(r => r.CustomerName == customerName).ToListAsync();
        }
    }
}