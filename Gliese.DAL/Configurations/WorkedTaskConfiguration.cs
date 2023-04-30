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
   public class WorkedTaskConfiguration : IEntityTypeConfiguration<WorkedTask>
    {
        public void Configure(EntityTypeBuilder<WorkedTask> builder)
        {
            builder.ToTable("WorkedTask");

            builder.HasKey(x => new { x.Id, x.IdUser });

            builder.HasOne(x => x.User)
                .WithMany(x => x.WorkedTask)
                .HasForeignKey(x => x.IdUser);
        }
    }
}
