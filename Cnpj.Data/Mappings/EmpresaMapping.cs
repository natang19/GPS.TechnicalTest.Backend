using Cnpj.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cnpj.Data.Mappings
{
    public class EmpresaMapping : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.data_situacao)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(p => p.nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.uf)
                .IsRequired()
                .HasColumnType("varchar(2)");

            builder.Property(p => p.telefone)
                .IsRequired()
                .HasColumnType("varchar(1000)");

            builder.Property(p => p.situacao)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.bairro)
               .IsRequired()
               .HasColumnType("varchar(200)");

            builder.Property(p => p.logradouro)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.numero)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(p => p.cep)
                .IsRequired()
                .HasColumnType("varchar(8)");

            builder.Property(p => p.municipio)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.porte)
                .IsRequired()
                .HasColumnType("varchar(15)");

            builder.Property(p => p.abertura)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(p => p.natureza_juridica)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.fantasia)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(p => p.cnpj)
                .IsRequired()
                .HasColumnType("varchar(14)");

            builder.Property(p => p.ultima_atualizacao)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(p => p.tipo)
                .IsRequired()
                .HasColumnType("varchar(6)");

            builder.Property(p => p.capital_social)
                .IsRequired()
                .HasColumnType("float");

            builder.ToTable("Empresas");
        }
    }
}
