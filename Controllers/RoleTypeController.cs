using ManagmentSystemAPI.Actions;
using ManagmentSystemAPI.Entities;
using ManagmentSystemAPI.Models;
using ManagmentSystemAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Description;

namespace ManagmentSystemAPI.Controllers
{
    public class RoleTypeController : ControllerBase
    {
        private readonly RoleTypeRepository roleTypeRepository;

        public RoleTypeController()
        {
            roleTypeRepository = new RoleTypeRepository();
        }

        [HttpGet]
        [Route("roletype/search")]
        [ResponseType(typeof(RoleType))]
        public ActionResult GetRoleTypeBy(int roleID)
        {
            if (roleID < 1)
            {
                return BadRequest("Insert A Value Greather than 0");
            }

            var roleType = roleTypeRepository.FindRoleTypeBy(roleID);

            if(roleType == null)
            {
                return NotFound();
            }
            else if(roleType != null)
            {
                return Ok(roleType);
            }
            else
            {
                return BadRequest("Something Went Wrong");
            }
        }
    }
}
