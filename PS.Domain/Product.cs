using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PS.Domain
{
    public enum PackagingType
    {
        Carton = 0, Plastic = 1
    };
    public class Product:Concept
    {
        [DataType(DataType.Date)]
        [Display(Name="Production Date")]
        public  DateTime DateProd{ get; set; }
          public string Image { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required(ErrorMessage="this field is required")]
        [StringLength(25,ErrorMessage ="max length 25")]
        [MaxLength(50,ErrorMessage ="max length  50")]
        //[Column("MyName")]
        public string Name { get; set; }
        [DataType(DataType.Currency)]
        public double Price { get; set; }
        public int ProductId { get; set; }
        [Range(0,int.MaxValue,ErrorMessage ="positif int")]
        public int  Quantity { get; set; }
        public virtual  IList<Provider> Providers { get; set; }
        [ForeignKey("MyCategory")]
        public int ? CategoryId { get; set; }
       //ou bien  :
     //  [ForeignKey("CategoryId")]
        public virtual  Category MyCategory { get; set; }
        public PackagingType MyPackagingType { get; set; } = 0;


        public virtual IList<Invoice> Invoices { get; set; }
        public override void GetDetails()
        {
            Console.WriteLine("name : " + Name + "Quantity : " + Quantity);           
        }

        public virtual String GetMyType()
        {
            return " UNKNOWN";
        }
    }
}
