using System.Data.Entity;

namespace ManagmentSystemAPI.Models
{
    public class SnowflakesDB:DbContext
    {
        public SnowflakesDB() : base("name=SnowflakesDB") => Database.SetInitializer<SnowflakesDB>(null);

        //TABLES IN SNOWFLAKESDB

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<RoleType> RoleTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            //CUSTOMER FIELDS

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

            modelBuilder.Entity<Customer>()
                .Property(e => e.RoleID);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Password);

            //ROLETYPE FIELDS
            modelBuilder.Entity<RoleType>()
                .Property(i => i.RoleID);

            modelBuilder.Entity<RoleType>()
                .Property(i => i.Role_name);


        }
    }
}
