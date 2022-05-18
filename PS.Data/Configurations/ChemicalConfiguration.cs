using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PS.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Data.Configurations
{
    public class ChemicalConfiguration : IEntityTypeConfiguration<Chemical>
    {
        public void Configure(EntityTypeBuilder<Chemical> builder)
        {
            builder.OwnsOne(chem => chem.address, adr =>
            {
                adr.Property(ad => ad.City).HasColumnName("MyCity").IsRequired();
                adr.Property(ad => ad.StreetAddress).HasColumnName("MyAddress").HasMaxLength(50);
            });
           //builder.ToTable("Chemicals");
        }
    }
}
