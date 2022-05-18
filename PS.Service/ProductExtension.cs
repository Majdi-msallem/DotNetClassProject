using PS.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Service
{
   public static  class ProductExtension
    {
        public static void UpperName(this ManageProduct p,Product prod)
        {
           
            prod.Name=    prod.Name.ToUpper();
                
            
            
        }
        public static bool InCategory(this ManageProduct p,Product prod ,Category category)
        {
            
                
        return prod.MyCategory == category ;
            

        }

    }
}
