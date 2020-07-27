using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entities.Certificate
{
    public class CertificateEntity
    {
        public int certificateId = 0;

        public string expirationDate = "";

        public Dictionary<string, string> getTrasformationMap()
        {
            var map = new Dictionary<string, string>
            {
                {"certificateId", ":certificateId"},
                {"expirationDate", ":expirationDate"},
            };
            return map;
        }
    }
}
