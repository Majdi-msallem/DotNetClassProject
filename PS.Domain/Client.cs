using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PS.Domain
{
    public class Client
    {
        [Key]
        public string Cin { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public virtual  IList<Invoice> Invoices { get; set; }
    }
}
