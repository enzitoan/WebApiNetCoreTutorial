using System;
using System.Collections.Generic;

namespace ChinookCoreAPI.Models
{
    public partial class Customers
    {
        public Customers()
        {
            Invoices = new HashSet<Invoices>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public int? EmployeeEmployeeId { get; set; }

        public virtual Employees EmployeeEmployee { get; set; }
        public virtual ICollection<Invoices> Invoices { get; set; }
    }
}
