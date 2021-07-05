using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayerProject.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);//PrimaryKey
            builder.Property(x => x.Id).UseIdentityColumn();//Birer birer artma

            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);//Name zorunlu olsun max200 karakter olsun
            builder.Property(x => x.Stock).IsRequired();//Stock zorunlu olsun

            builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(18,2)");//18 karakter olacak virgülden sonra 2 değer alacak. 

            builder.Property(x => x.InnerBarcode).HasMaxLength(50);

            builder.ToTable("Products");

        }
    }
}
