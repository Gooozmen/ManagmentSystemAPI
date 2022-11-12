using ManagmentSystemAPI.Models;
using ManagmentSystemAPI.Repositories;
using ManagmentSystemAPI.Entities;

namespace ManagmentSystemAPI.Actions
{
    public class CustomerActions
    {
        private readonly SnowflakesDB db;
        private readonly CustomerRepository customerRepository;
        private readonly RoleTypeRepository roleTypeRepository;

        public CustomerActions()
        {
            db = new SnowflakesDB();
            roleTypeRepository = new RoleTypeRepository();
            customerRepository = new CustomerRepository();
        }


        public bool CustomerExists(string username)
        {
            if(customerRepository.FindCustomerBy(username) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
