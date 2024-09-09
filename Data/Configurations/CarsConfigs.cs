using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;

namespace Data.Configurations
{
    public class ProductConfigs : IEntityTypeConfiguration<Cars>
    {
        public void Configure(EntityTypeBuilder<Cars> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);

            builder.Property(x => x.Archived).HasDefaultValue(false);

            builder
                .HasOne(x => x.Category)
                .WithMany(x => x.Cars)
                .HasForeignKey(x => x.CategoryId);
        }
    }
}
