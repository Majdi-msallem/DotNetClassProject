using Microsoft.Extensions.DependencyInjection;
using ProductStore.Data.Infrastructure;
using PS.Data;
using PS.Data.Infrastructures;
using PS.Domain;
using PS.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PS.Console
{
   public  class Program
    {
        static void Main(string[] args)
        {
            /*
            ManageProduct k = new ManageProduct();
            k.products = new System.Collections.Generic.List<Product>();
           
              Product Prod = new Product() { Name = "Tropico",Description="Vitamine C",Price =14000 };
             Product Bio = new Biological() { Name = "Khalifa", Herb = "irirs" };
            Product chem = new Chemical() { Name = "Kkaka", City = "Tunis" };


            k.products.Add(chem);
            k.GetChemicalGroupByCity();
           k.UpperName(chem);
            System.Console.WriteLine(k.InCategory(chem,null));
           // Prod.GetDetails();
           //Bio.GetDetails();
           Provider prov = new Provider() { Password="123456",ConfirmPassword="123456",IsApproved=false,UserName="Aymen",Email="a"};
            //bool x=false;
            //Provider.SetIsApproved("123456","123" ,ref x);

            //Provider.SetIsApproved(prov);

           // System.Console.WriteLine(prov.Login("Aymen","123456", "a"));
            //System.Console.WriteLine( x);
            System.Console.WriteLine(Bio.GetMyType());

            */
            ////////////////////22/02/2022
            /*  Product chem = new Chemical() { Name = "Aymen",DateProd=DateTime.Now,Image="zeidi" };



              PSContext ctxt = new PSContext();
              ctxt.Products.Add(chem);
              System.Console.WriteLine(ctxt.Products);
              ctxt.SaveChanges();*/
            #region 28/03/2022

            //Category cat = new Category() { Name = "cat" };
            //Product prod1 = new Product()
            /*{ Name = "prod22", DateProd = DateTime.Now, Quantity = 5,MyCategory=cat };
             PSContext ctxt1 = new PSContext();
            ctxt1.Products.Add(prod1);
            ctxt1.Catgegories.Add(cat);
            ctxt1.SaveChanges();

            Product p2 = ctxt1.Products.Find(prod1.ProductId);
            p2.GetDetails();
            p2.MyCategory.GetDetails();
            IDatabaseFactory ctxt2 = new IDatabaseFactory();
            Product p3 = ctxt2.Products.Where(p => p.ProductId == 15).FirstOrDefault();
            p3.GetDetails();
            p3.MyCategory.GetDetails();*/

            #endregion
            #region 7/5/22
            Product prod1 = new Product()
            { Name = "prod7522", DateProd = DateTime.Now, Quantity = 5 };
            IDataBaseFactory dbf = new DataBaseFactory();
            IUnitOfWork uow = new UnitOfWork(dbf);
            uow.getRepository<Product>().Add(prod1);
            uow.Commit();
            uow.Dispose();
            #endregion


        }


    }
}
