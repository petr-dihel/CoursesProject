using Database.Entities.Administrator;
using Database.Mappers.Administrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Services
{
    public class AdministratorService
    {

        private AdministratorMapper administratorMapper;

        public AdministratorService()
        {
            this.administratorMapper = new AdministratorMapper();
        }

        public AdministratorEntity tryLogIn(string email, string password)
        {
            return this.administratorMapper.GetByEmailAndPassword(email, password);
        }

    }
}
