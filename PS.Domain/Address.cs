using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace PS.Domain
{
    [Owned]
    public  class Address
    {
        public string StreetAddress { get; set; }
        public string City { get; set; }
    }
}
