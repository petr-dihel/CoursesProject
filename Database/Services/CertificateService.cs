using Database.Mappers.Certificate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Services
{
    public class CertificateService
    {

        private CertificateMapper certificateMapper;

        public CertificateService()
        {
            certificateMapper = new CertificateMapper();
        }

        public void InsertCertificates(int courseId, DateTime expirationDate)
        {

        }
    }
}
