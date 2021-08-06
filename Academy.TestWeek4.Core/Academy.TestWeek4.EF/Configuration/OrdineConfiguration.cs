using Academy.TestWeek4.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Academy.TestWeek4.EF
{
    public class OrdineConfiguration : IEntityTypeConfiguration<Ordine>
    {
        public void Configure(EntityTypeBuilder<Ordine> builder)
        {
            builder
                .HasKey(l => l.ID);



            builder
                .Property(d => d.DataOrdine)
                .IsRequired();

            builder
                .Property(c => c.CodiceOrdine)
                .HasMaxLength(20)
                .IsRequired();
            builder
                .Property(c => c.CodiceProdotto)
                .HasMaxLength(20)
                .IsRequired();
            builder
                .Property(i => i.Importo)
                .IsRequired();

            builder
                .HasOne(c => c.Cliente)
                .WithMany(o => o.Ordini);


        }
    }
}