using Cnpj.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cnpj.Data.Mappings
{
    public class CnpjInfoMapping : IEntityTypeConfiguration<CnpjInfo>
    {
        public void Configure(EntityTypeBuilder<CnpjInfo> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.ToTable("CnpjInfo");
        }
    }
}
