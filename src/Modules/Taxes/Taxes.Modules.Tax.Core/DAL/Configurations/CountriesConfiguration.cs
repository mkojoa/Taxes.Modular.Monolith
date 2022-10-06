using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taxes.Shared.Abstractions.Kernel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxes.Shared.Abstractions.Kernel.Entites;

namespace Taxes.Modules.Tax.Core.DAL.Configurations
{
    internal class CountriesConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(x => x.Code);

            builder.Property(x => x.Code)
              .HasMaxLength(50)
              .IsRequired()
              .HasConversion(x => x.Value, x => new Code(x));

            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .HasConversion(x => x.Value, x => new Name(x));

            builder.Property(x => x.Demonym)
              .IsRequired()
              .HasMaxLength(50);
        }
    }
}
