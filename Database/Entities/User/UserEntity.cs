using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entities.User
{
    public class UserEntity : IEntity
    {

        public int userId = 0;

        public string name = "";

        public string surname = "";

        public string email = "";

        public string password = "";

        public DateTime date_of_birth;

        public int addresId = 0;

        public float totalPaid = 0;

        public bool inDebt = false;

        public Dictionary<string, string> getTrasformationMap()
        {
            var map = new Dictionary<string, string>
            {
                {"userId", ":userId"},
                {"name", ":name"},
                {"surname", ":surname"},
                {"email", ":email"},
                {"password", ":password"},
                {"date_of_birth", ":date_of_birth"},
                {"addresId", ":addresId"},
                {"totalPaid", ":totalPaid"},
                {"inDebt", ":inDebt"},
            };
            return map;
        }

    }
}
