using PS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PS.Service
{
   public  class ManageProvider
    {

        public IList<Provider> Providers { get; set; }
        public List<Provider> GetProviderByName(String Name)
        {
            return (from prof in Providers
                    where prof.UserName.Contains(Name)
                    select prof).ToList();
        }

        public Provider GetFirstProvider(String Name)
        {
            return (from prof in Providers
                    where prof.UserName.StartsWith(Name)
                    select prof
                    ).First();
       }
        public Provider GetProviderById(int id )
        {
            return (from prof in Providers
                    where prof.Id == id
                    select prof).Single();
        }

    }
   
}
