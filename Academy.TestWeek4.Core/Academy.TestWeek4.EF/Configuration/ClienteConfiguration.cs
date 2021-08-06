using Academy.TestWeek4.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Academy.TestWeek4.EF
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder
                .HasKey(b => b.ID);

            builder
                .Property(c => c.CodiceCliente)
                .HasMaxLength(20)
                .IsRequired();

            builder
                .Property(n => n.Nome)
                .HasMaxLength(20)
                .IsRequired();

            builder
                .Property(c => c.Cognome)
                .HasMaxLength(20)
                .IsRequired();

            builder
               .HasMany(o => o.Ordini)
               .WithOne(c => c.Cliente);


        }
    }
}