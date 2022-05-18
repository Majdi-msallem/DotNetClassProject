using PS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PS.Service
{
    public delegate List<Product> FindProductDelegate(Char s, List<Product> p);
    public delegate List<Product> ScanProductDelegate(Category c, List<Product> p);
    public class ManageProduct
    {
        public List<Product> products { get; set; }
       


     public ManageProduct()
        {
            FindProductDelegate findProductDelegate =  delegate (Char s, List<Product> p)
            {
                return (List<Product>)p.Where(x => x.Name.StartsWith(s));
            };

            ScanProductDelegate scanProductDelegate =  delegate (Category s, List<Product> p)
            {
                return (List<Product>)p.Where(x => x.MyCategory == s);
            };
        }


        List<Product> FindProduct(String s)
       
            => products.Where(x => x.Name.StartsWith(s)).ToList();

        void ScanProduct(Category c)
        {
            var p = products.Where(x => x.MyCategory.CategoryId == c.CategoryId).ToList();
               foreach (Product k in p)
            {
                k.GetDetails();
            }
        }

    public List<Product> GetChemicals(double price)
        {
            return (from p in products
                    where
p.Price >= price
                    select p).Take(5).ToList();
        }
        public List<Product> GetProductPrice(double price)
        {
            return (from v in products
                    where v.Price > price
                    select v).Skip(2).ToList();
        }
        public double GetAveragePrice()
        {
            return (from v in products select v.Price).Average();
        }
        public Product GetMaxPrice()
        {
            return (from v in products

                    orderby v.Price descending
                    select v).FirstOrDefault();
        }
        public int GetCountProduct(string city)
        {
            return (from v in products
                    where ((Chemical)v).address.City == city
                    select v.Price
                    ).Count();
        }

        public List<Chemical> GetChemicalCity()
        {
            return (from v in products orderby ((Chemical)v).address.City

                    select (Chemical)v
                    ).ToList();
        }

        public IEnumerable<IGrouping<string,Product>> GetChemicalGroupByCity()
        {
           var rs = (from v in products
                    orderby ((Chemical)v).address.City
                    group ((Chemical)v) by ((Chemical)v).address.City
                    );


            foreach(var prop in rs)
            {
                System.Console.WriteLine(prop.Key);
                foreach (var p in prop)
                {
                    p.GetDetails();
                }

            }
            return rs;
        }

      
    
    }
}
