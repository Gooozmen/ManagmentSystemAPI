using System;

namespace ManagmentSystemAPI.Entities
{
    public class User
    {
        private string username;
        private string name;
        private string last_name;
        private int dni;
        private string phone;
        private string email;
  
        public string Username { get => username; set => username = value; }
        public string Name { get => name; set => name = value; }
        public string Last_name { get => last_name; set => last_name = value; }
        public int Dni { get => dni; set => dni = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
    }
}
