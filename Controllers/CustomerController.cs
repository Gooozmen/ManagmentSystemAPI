using ManagmentSystemAPI.Actions;
using ManagmentSystemAPI.Entities;
using ManagmentSystemAPI.Models;
using ManagmentSystemAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Description;

namespace ManagmentSystemAPI.Controllers
{
    public class CustomerController : ControllerBase
    {
        private readonly CustomerRepository customerRepository;
        private readonly CustomerActions customerActions;
        private readonly RoleTypeActions roleTypeActions;

        public CustomerController()
        {
            customerRepository = new CustomerRepository();
            customerActions = new CustomerActions();
            roleTypeActions = new RoleTypeActions();
        }

        [HttpGet]
        [Route("customer/search")]
        [ResponseType(typeof(User))]
        public ActionResult GetCustomerBy(string username)
        {
            if(username == null)
            {
                return BadRequest("Username parameter has null reference value");
            }
            else if(username != null && customerActions.CustomerExists(username))
            {
                var user = customerRepository.ReadSingleCustomerBy(username);
                user.UserRole.Role_name = roleTypeActions.GetRoleNameOf(user);
                return Ok(user);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("customer")]
        [ResponseType(typeof(User))]
        public ActionResult GetCustomers()
        {
            List<User> users = customerRepository.ReadCustomers();

            if(users == null)
            {
                return NotFound();
            }

            else if (users != null)
            {
                users = roleTypeActions.GetRoleNamesOf(users);
                return Ok(users);
            }

            else
            {
                return BadRequest("Something went wrong");
            }
        }

        [HttpPost]
        [Route("customer")]
        [ResponseType(typeof(bool))]
        public ActionResult PostCustomer([FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest("Customer Has Null Reference Value");
            }
            else if (customerRepository.FindCustomerBy(customer.Username) == null)
            {
                var response = customerRepository.CreateCustomer(customer);

                if (response != null)
                {
                    return Ok(response);
                }
            }
            return BadRequest("Customer Already Exists");
        }

        [HttpDelete]
        [Route("customer")]
        [ResponseType(typeof(void))]
        public ActionResult DeleteCustomer(string username)
        {
            var result = customerRepository.RemoveCustomer(username);

            if (result == false)
            {
                return NotFound();
            }
            else if(result == true)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("The Customer Doesnt Exists On The System");
            }
        }

        [HttpPatch]
        [Route("customer")]
        [ResponseType(typeof(Customer))]
        public ActionResult UpdateCustomer(string username, string phone, string email)
        {
            if(username == string.Empty || username == null)
            {
                return BadRequest("Username Provided With Null Reference Value");
            }
            else if(customerRepository.FindCustomerBy(username) == null)
            {
                return NotFound();
            }    
            else if(phone == string.Empty && phone == string.Empty)
            {
                return BadRequest("Either Phone or Email parameter have to be inserted or both");
            }
            else
            {
                var result = customerRepository.UpdateCustomer(username, phone, email);
                return Ok(result);
            }
        }
    }
}
