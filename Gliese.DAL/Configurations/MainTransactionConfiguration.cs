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
    public class MainTransactionConfiguration : IEntityTypeConfiguration<MainTransaction>
    {
        public void Configure(EntityTypeBuilder<MainTransaction> builder)
        {
            builder.ToTable("MainTransaction");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.TransactionType)
                .WithMany(x => x.MainTransaction)
                .HasForeignKey(x => x.IdTransactionType);
        }
    }
}
