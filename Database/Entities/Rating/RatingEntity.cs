using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entities.Rating
{
    public class RatingEntity
    {
        public int userId = 0;

        public int teacherId = 0;

        public int points = 0;

        public Dictionary<string, string> getTrasformationMap()
        {
            var map = new Dictionary<string, string>
            {
                {"userId", ":userId"},
                {"teacherId", ":teacherId"},
                {"points", ":points"},
            };
            return map;
        }
    }
}
