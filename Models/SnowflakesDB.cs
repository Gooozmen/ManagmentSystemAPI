using System.Data.Entity;

namespace ManagmentSystemAPI.Models
{
    public class SnowflakesDB:DbContext
    {
        public SnowflakesDB() : base("name=SnowflakesDB") => Database.SetInitializer<SnowflakesDB>(null);

        public virtual DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(e => e.Username);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Name);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Last_name);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Dni);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Phone);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Email);
        }
    }
}
