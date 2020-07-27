using Database.Entities.Invoice;
using Database.Mappers.Invoice;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Services
{
    public class InvoiceService
    {

        private InvoiceMapper invoiceMapper;

        public InvoiceService()
        {
            this.invoiceMapper = new InvoiceMapper();
        }

        public Collection<InvoiceEntity> getUsersInvoices(int userId)
        {
            return this.invoiceMapper.getUsersInvoices(userId);
        }

        public float getCoursePrice(int courseId) {
            return this.invoiceMapper.getPrice(courseId);
        }

    }
}
