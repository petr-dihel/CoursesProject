using Database.Entities.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entities.Course
{
    public class CourseEntity
    {
        public int courseId = 0;

        public string date = "";

        public int duration = 0;

        public string subject = "";

        public int minRequiredPoints = 0;

        public float price = 0;

        public int teacherId = 0;

        public TeacherEntity teacher = null;

        public Dictionary<string, string> getTrasformationMap()
        {
            var map = new Dictionary<string, string>
            {
                {"\"date\"", ":date"},
                {"duration", ":duration"},
                {"subject", ":subject"},
                {"minRequiredPoints", ":minRequiredPoints"},
                {"price", ":price"},
                {"teacher", ":teacherId"},
            };
            return map;
        }
    }
}
