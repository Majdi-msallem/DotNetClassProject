using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Domain
{
  public   class Chemical:Product
    {
     
        public string LabName { get; set; }
        public  Address address { get; set; }
        public override string GetMyType()
        {
            return "Chemical";
        }

    }
}
