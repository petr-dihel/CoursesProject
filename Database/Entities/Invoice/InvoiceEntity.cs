using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entities.Invoice
{
    public class InvoiceEntity
    {
        public int invoiceId = 0;

        public bool paid = false;

        public string dateCreated = "";

        public string dueDate = "";

        public Dictionary<string, string> getTrasformationMap()
        {
            var map = new Dictionary<string, string>
            {
                {"invoiceId", ":invoiceId"},
                {"paid", ":paid"},
                {"dateCreated", ":dateCreated"},
                {"dueDate", ":dueDate"},
            };
            return map;
        }
    }
}
