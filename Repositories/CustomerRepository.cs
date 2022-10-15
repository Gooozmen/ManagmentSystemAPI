using ManagmentSystemAPI.Entities;
using ManagmentSystemAPI.Models;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;

namespace ManagmentSystemAPI.Repositories
{
    public class CustomerRepository
    {
        public SnowflakesDB db;

        public CustomerRepository()
        {
            db = new SnowflakesDB();
        }

        //DEFINING CRUD OPERATIONS

        public List<User> ReadCustomers()
        {
            return db.Customers
                .Select(x => new User()
                {
                    Username = x.Username,
                    Name = x.Name,
                    Last_name = x.Last_name,
                    Dni = x.Dni,
                    Phone = x.Phone,
                    Email = x.Email,
                }).ToList();
        }

        internal Customer CreateCustomer(Customer customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();
            return customer;
        }

        public bool UpdateCustomer(string username, string? phone, string? email)
        {
            if(phone == null)
            {
                db.Database.ExecuteSqlCommand("UPDATE Customer SET Email = @email WHERE Username = @username",
                                              new SqlParameter("@username", username),
                                              new SqlParameter("@email", email));
            }
            if (email == null)
            {
                db.Database.ExecuteSqlCommand("UPDATE Customer SET Phone = @phone WHERE Username = @username",
                                              new SqlParameter("@username", username),
                                              new SqlParameter("@phone", phone));  
            }

            try
            {
                db.SaveChanges();
                return true ;
            }
            catch (DbUpdateException)
            {
                return false;   
            }
        }

        public Customer FindCustomerByUsername(string username)
        {
            return db.Customers.Find(username);
        }

        public bool RemoveCustomer(string username)
        {
            Customer user = db.Customers.Find(username);

            if (user == null) { return false; }

            else
            {
                db.Customers.Remove(user);
                db.SaveChanges();
                return true;
            }
        }
    }
}
