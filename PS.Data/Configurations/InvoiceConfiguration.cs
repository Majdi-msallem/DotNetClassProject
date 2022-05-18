using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PS.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Data.Configurations
{
    class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasOne(prod => prod.MyProduct)
                .WithMany(Inv => Inv.Invoices).HasForeignKey(inv=>inv.ProductFK);
            builder.HasOne(Cl => Cl.MyClient)
                .WithMany(Inv => Inv.Invoices).HasForeignKey(inv => inv.ClientFK);
            builder.HasKey(inv => new { inv.ClientFK, inv.ProductFK, inv.PurchaseDate });
        }
    }
}
