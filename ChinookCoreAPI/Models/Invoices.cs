using System;
using System.Collections.Generic;

namespace ChinookCoreAPI.Models
{
    public partial class Invoices
    {
        public Invoices()
        {
            InvoiceLines = new HashSet<InvoiceLines>();
        }

        public int InvoiceId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string BillingAddress { get; set; }
        public string BillingCity { get; set; }
        public string BillingState { get; set; }
        public string BillingCountry { get; set; }
        public string BillingPostalCode { get; set; }
        public decimal Total { get; set; }
        public int CustomerCustomerId { get; set; }

        public virtual Customers CustomerCustomer { get; set; }
        public virtual ICollection<InvoiceLines> InvoiceLines { get; set; }
    }
}
