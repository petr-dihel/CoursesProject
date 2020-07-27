using Database.Entities.Address;
using Database.Entities.Teacher;
using Database.Mappers.Address;
using Database.Mappers.Teacher;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Services
{
    public class TeacherService
    {
        private TeacherMapper teacherMapper;

        public TeacherService()
        {
            this.teacherMapper = new TeacherMapper();        
        }

        public Collection<TeacherEntity> getAll()
        {
            return this.teacherMapper.Select();
        }

        public TeacherEntity TryLogIn(string email, string password)
        {
            return this.teacherMapper.GetByEmailAndPassword(email, password);
        }

        public TeacherEntity GetById(int teacherId)
        {
            return this.teacherMapper.Select(teacherId);
        }

        public void Insert(TeacherEntity teacher)
        {
            this.teacherMapper.Insert(teacher);
        }
    }
}
