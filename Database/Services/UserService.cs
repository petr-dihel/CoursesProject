using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Mappers.User;
using Database.Entities.User;

namespace Database.Services
{
    public class UserService
    {

        private UserMapper userMapper = null;

        private UserEntity loggedUser = null;

        public UserService()
        {
            this.userMapper = new UserMapper();
        }
        
        public UserEntity TryLogin(string email, string password)
        {
            this.loggedUser = this.userMapper.GetByEmailAndPassword(email, password);
            return this.loggedUser;
        }

        public void SetDebts()
        {
            this.userMapper.SetDebts();
        }

    }
}
