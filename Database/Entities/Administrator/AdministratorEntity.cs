using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entities.Administrator
{
    public class AdministratorEntity : IEntity
    {
        public int administratorId = 0;

        public string password = "";

        public string email = "";

        public Dictionary<string, string> getTrasformationMap()
        {
            var map = new Dictionary<string, string>
            {
                {"administratorId", ":administratorId"},
                {"password", ":password"},
                {"email", ":email"},
            };
            return map;
        }
    }
}
