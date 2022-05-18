using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Domain
{
    public class Invoice
    {
       
        public DateTime PurchaseDate { get; set; }
        public float Price { get; set; }
        public virtual Client MyClient { get; set; }
        public virtual Product MyProduct { get; set; }

        public string ClientFK { get; set; }
        public int ProductFK { get; set; }
    }
}
