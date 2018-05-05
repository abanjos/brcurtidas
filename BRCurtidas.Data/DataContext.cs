using Microsoft.EntityFrameworkCore;

namespace BRCurtidas.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }

        public virtual DbSet<Address> Addresses { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<Payment> Payments { get; set; }

        public virtual DbSet<Service> Services { get; set; }

        public virtual DbSet<User> Users { get; set; }
    }
}
