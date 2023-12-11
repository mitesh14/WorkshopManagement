using Microsoft.EntityFrameworkCore;

namespace WorkshopManagement.Models
{
    public class WorkshopDbContext : DbContext
    {

        public WorkshopDbContext(DbContextOptions<WorkshopDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<WorkshopSlot> WorkshopSlots { get; set; }


    }
}
