using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Mappers.Course;
using Database.Entities.Course;
using System.Collections.ObjectModel;
using Database.Mappers.Teacher;
using Database.Entities.Teacher;

namespace Database.Services
{
    public class CourseService
    {
        private CourseMapper courseMapper = null;

        public CourseService()
        {
            this.courseMapper = new CourseMapper();
        }

        public Collection<CourseEntity> getAll()
        {
            return this.courseMapper.Select();
        }

        public TeacherEntity GetCourseTeacher(int teacherId)
        {
            TeacherMapper teacherMapper = new TeacherMapper();
            TeacherEntity teacher = teacherMapper.Select(teacherId);
            return teacher;
        }

        public Collection<CourseEntity> GetBysubject(string searchTerm)
        {
            return this.courseMapper.getBysubject(searchTerm);
        }

        public void InsertIntoUserCourse(string userId, string courseId)
        {
            this.courseMapper.InsertIntoUserCourse(userId, courseId);
        }

        public Collection<CourseEntity> getUserCourse(int userId)
        {
            return this.courseMapper.getUserCourse(userId);
        }

        public void Insert(CourseEntity entity)
        {
            this.courseMapper.Insert(entity);
        }

        public bool isSignedToCourse(string courseId, string userId)
        {
            return this.courseMapper.isSignedToCourse(Int32.Parse(courseId), Int32.Parse(userId));
        }
    }
}
