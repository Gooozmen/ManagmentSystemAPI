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

        public CustomerController()
        {
            customerRepository = new CustomerRepository();
            customerActions = new CustomerActions();
        }

        [HttpGet]
        [Route("customer/search")]
        [ResponseType(typeof(void))]
        public ActionResult GetCustomerBy(string username)
        {
            if(username != null)
            {
                var response = customerRepository.FindCustomerByUsername(username);
                return Ok(response);
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

            if (users != null)
            {
                return Ok(users);
            }
            else
            {
                return null;
            }
        }

        [HttpPost]
        [Route("customer")]
        [ResponseType(typeof(void))]
        public ActionResult PostCustomer([FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest("Customer Has Null Reference Value");
            }
            else if (!customerActions.CustomerExists(customer))
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
            else if(customerRepository.FindCustomerByUsername(username) == null)
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
