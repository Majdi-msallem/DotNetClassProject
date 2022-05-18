using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PS.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasMany(prod => prod.Providers).WithMany(prov => prov.Products)
                .UsingEntity(ass=>ass.ToTable("ProdProv"));
            builder.HasOne(prod => prod.MyCategory).WithMany(cat => cat.Products)
                .HasForeignKey(prod=>prod.CategoryId)
                .OnDelete(DeleteBehavior.SetNull);
     
            /* builder.HasDiscriminator<int>("isBiological")
                .HasValue<Biological>(1)
                .HasValue<Chemical>(2)
                .HasValue<Product>(0); */
        }
    }
}
