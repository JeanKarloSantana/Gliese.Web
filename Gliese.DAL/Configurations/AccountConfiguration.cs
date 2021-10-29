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
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Account");

            builder.HasKey(k => k.Id);

            builder.HasOne(c => c.Currency)
                .WithMany(a => a.Account)
                .HasForeignKey(c => c.IdAccCurrency);

            builder.HasOne(c => c.User)
                .WithMany(a => a.Account)
                .HasForeignKey(c => c.IdAccUser);
        }
    }
}
