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

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<PaymentType> PaymentTypes { get; set;}

        public virtual DbSet<SocialNetwork> SocialNetworks { get; set; }

        public virtual DbSet<ServiceType> ServiceTypes { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<ServiceScope> ServiceScopes { get; set; }

        public virtual DbSet<ScopedServiceType> ScopedServiceTypes { get; set; }

    }
}
