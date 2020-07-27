using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entities.Teacher
{
    public class TeacherEntity : IEntity
    {

        public int teacherId = 0;

        public string password = "";

        public string name = "";

        public string surname = "";

        public string telephone = "";

        public DateTime date_of_birth;

        public string email = "";

        public float averageRating = 0;


        public Dictionary<string, string> getTrasformationMap()
        {
            var map = new Dictionary<string, string>
            {
                {"teacherId", ":teacherId"},
                {"password", ":password"},
                {"name", ":name"},
                {"surname", ":surname"},
                {"telephone", ":telephone"},
                {"date_of_birth", ":date_of_birth"},
                {"email", ":email"},
                {"averageRating", ":averageRating"},
            };
            return map;
        }

    }
}
