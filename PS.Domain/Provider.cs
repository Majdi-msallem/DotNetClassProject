using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PS.Domain
{
    public class Provider : Concept
    {
        [Required(ErrorMessage = "this field is required")]
        [NotMapped]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="dosen't match with field password")]
        public String ConfirmPassword { get; set; }
        public DateTime DateCreated { get; set; }
        // ou bien : [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage ="this field is required")]
        public String Email { get; set; }
        //[Key]
        public  int Id { get; set; }
        public bool IsApproved { get; set; }
        String password ;
        [Required(ErrorMessage = "this field is required")]
        [MinLength(8, ErrorMessage = "min length is 8")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string UserName { get; set; }
        public virtual IList<Product> Products { get; set; }
        public override void GetDetails()
        {
            Console.WriteLine("Name : " + UserName + "Email : " + Email);
            foreach (Product p in Products)
                Console.WriteLine(p.Name);

        }

        public static  void SetIsApproved ( Provider p )
        {

            p.IsApproved = p.Password == p.ConfirmPassword ? true : false;
        }

        public static void SetIsApproved(string password , string confirmPassword ,ref bool isApproved)
        {

            isApproved = password == confirmPassword;
        }

        public bool Login (String ui , String mdp,String email =null)
        {
            if (email != null)
            return mdp == password && ui == UserName&& email == Email;

            else
                return mdp == password && ui == UserName ;
        }

       


        public void GetProducts(String filterType, String filterValue)
        {
            

            switch (filterType)
            {
                case "Description":
                    foreach (Product p in Products)
                    {
                        if (filterValue == p.Description)
                            p.GetDetails();
                    }
                    break;
                case "Name":
                    foreach (Product p in Products)
                    {
                        if (filterValue == p.Name)
                            p.GetDetails();
                    }
                    break;
                case "ProductId":
                    foreach (Product p in Products)
                    {
                        if (int.Parse(filterValue) == p.ProductId)
                            Console.WriteLine(p);
                    }
                    break;
                case "DateProd":
                    foreach (Product p in Products)
                    {
                        if (DateTime.Parse(filterValue) == p.DateProd)
                            Console.WriteLine(p);
                    }
                    break;
                default:
                    Console.WriteLine("filtre inconnu");
                    break;
            }
        }
    }
    }