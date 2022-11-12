using ManagmentSystemAPI.Models;
using ManagmentSystemAPI.Repositories;
using ManagmentSystemAPI.Entities;

namespace ManagmentSystemAPI.Actions
{
    public class RoleTypeActions
    {
        private readonly SnowflakesDB db;
        private readonly RoleTypeRepository roleTypeRepository;

        public RoleTypeActions()
        {
            db = new SnowflakesDB();
            roleTypeRepository = new RoleTypeRepository();
        }

        public string GetRoleNameOf(User user)
        {
            RoleType roleType = roleTypeRepository.FindRoleTypeBy(user.UserRole.RoleID);

            return roleType.Role_name;
        }

        public List<User> GetRoleNamesOf(List<User> users)
        {
            foreach(User user in users)
            {
               user.UserRole.Role_name =  GetRoleNameOf(user);
            }
            return users;
        }

    }
}
