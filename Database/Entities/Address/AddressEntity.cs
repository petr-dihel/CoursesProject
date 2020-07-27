using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entities.Address
{
    public class AddressEntity : IEntity
    {
        public int addressId = 0;

        public string city = "";

        public string postCode = "";

        public string street = "";

        public string state = "";

        public Dictionary<string, string> getTrasformationMap()
        {
            var map = new Dictionary<string, string>
            {
                {"addressId", ":addressId"},
                {"city", ":city"},
                {"postCode", ":postCode"},
                {"street", ":street"},
                {"state", ":state"},
            };
            return map;
        }
    }
}
