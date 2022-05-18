using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Domain
{
   public  class Biological:Product
    {
        public string Herb { get; set; }


        public override string GetMyType()
        {
            return "biological";
        }
    }
   

}
