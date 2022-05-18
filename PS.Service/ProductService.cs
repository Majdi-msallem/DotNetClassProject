using ProductStore.Data.Infrastructure;
using PS.Data.Infrastructures;
using PS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;


namespace PS.Service
{
    public class ProductService : Service<Product>,IProductService
    {
        IDataBaseFactory dbf;
        
        readonly IUnitOfWork utk;
        public ProductService(IUnitOfWork utk ):base(utk)
        {
            this.utk = utk;
        }

        public void DeleteOldProducts()
        {
            Delete(p => p.DateProd.AddYears(1) < DateTime.Now);     
        }

        public IList<Product> FindMost5ExpensiveProds()
        {
            return GetAll().OrderByDescending(x => x.Price).Take(5).ToList();
        }

        public IList<Product> GetProdByClient(Client c)
        {
            return GetAll().SelectMany(p => p.Invoices)
                .Where(i => i.MyClient.Cin .Equals (c.Cin))
                .Select(p=>p.MyProduct).Distinct().ToList();
        }

        public float UnavailableProdPercentage()
        {
            return  ((float) (GetAll().Where(x => x.Quantity == 0).Count()) / (float) (GetAll().Count()))  *100; 
        }
    }
}
