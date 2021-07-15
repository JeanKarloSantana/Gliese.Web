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
    public class PurchaseTransactionConfiguration : IEntityTypeConfiguration<PurchaseTransaction>
    {
        public void Configure(EntityTypeBuilder<PurchaseTransaction> builder)
        {
            builder.ToTable("PurchaseTransaction");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.ExchangeRate)
                .WithMany(x => x.PurchaseTransaction)
                .HasForeignKey(x => x.IdExchangeRate);
        }
    }
}
