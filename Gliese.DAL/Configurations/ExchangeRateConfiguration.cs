using Gliese.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gliese.DAL.Configurations
{
    public class ExchangeRateConfiguration : IEntityTypeConfiguration<ExchangeRate>
    {
        public void Configure(EntityTypeBuilder<ExchangeRate> builder)
        {
            builder.ToTable("ExchangeRate");

            builder.HasKey(x => x.Id);

            builder.HasOne(e => e.CurrencyFrom)
                .WithMany(e => e.ExchangeRatesFrom)
                .HasForeignKey(e => e.IdFromCurrency)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.CurrencyTo)
                .WithMany(e => e.ExchangeRatesTo)
                .HasForeignKey(e => e.IdToCurrency)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
