namespace ManagmentSystemAPI.Entities
{
    public class UserRole
    {

        private int roleID;
        private string role_name;

        public int RoleID { get => roleID; set => roleID = value; }
        public string Role_name { get => role_name; set => role_name = value; }
    }
}
