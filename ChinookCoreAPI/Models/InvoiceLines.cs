using System;
using System.Collections.Generic;

namespace ChinookCoreAPI.Models
{
    public partial class InvoiceLines
    {
        public int InvoiceLineId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int InvoiceInvoiceId { get; set; }
        public int TrackTrackId { get; set; }

        public virtual Invoices InvoiceInvoice { get; set; }
        public virtual Tracks TrackTrack { get; set; }
    }
}
