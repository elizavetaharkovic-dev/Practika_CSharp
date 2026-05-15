using Microsoft.EntityFrameworkCore;
using PhotoGallery.Models;

namespace PhotoGallery.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ImageItem> ImageItems { get; set; }
    }
}