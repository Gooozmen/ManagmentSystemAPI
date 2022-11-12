using ManagmentSystemAPI.Entities;
using ManagmentSystemAPI.Models;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;

namespace ManagmentSystemAPI.Repositories
{
    public class RoleTypeRepository
    {
        public SnowflakesDB db;

        public RoleTypeRepository()
        {
            db = new SnowflakesDB();
        }

        public List<UserRole> ReadRoleTypes()
        {
            return db.RoleTypes
                .Select(r => new UserRole()
                {
                    RoleID = r.RoleID,
                    Role_name = r.Role_name,
                }).ToList();
        }
        internal RoleType CreateRoleType(RoleType UserRole)
        {
            db.RoleTypes.Add(UserRole);
            db.SaveChanges();
            return UserRole;
        }

        public bool UpdateRoleType(int roleID, string roleName)
        {
            db.Database.ExecuteSqlCommand("UPDATE RoleType SET RoleName = @roleName" +
                                          "WHERE RoleID = @roleID",
                                          new SqlParameter("@roleName", roleName),
                                          new SqlParameter("@roleID", roleID));
            try
            {
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public RoleType FindRoleTypeBy(int roleID)
        {
            return db.RoleTypes.Find(roleID);
        }
    }
}
