using ManagmentSystemAPI.Models;
using ManagmentSystemAPI.Repositories;

namespace ManagmentSystemAPI.Actions
{
    public class CustomerActions
    {
        private readonly SnowflakesDB db;

        public CustomerActions()
        {
            db = new SnowflakesDB();
        }
    }
}
