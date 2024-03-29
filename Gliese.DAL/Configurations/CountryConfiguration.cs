﻿using Gliese.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gliese.DAL.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Country");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Currency)
                .WithMany(x => x.Country)
                .HasForeignKey(x => x.IdCurrency)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
