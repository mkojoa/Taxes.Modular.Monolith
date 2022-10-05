using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taxes.Modules.Tax.Core.Domain.Entities;

namespace Taxes.Modules.Tax.Core.DAL.Configurations
{
    internal class TaxBandTableConfiguration : IEntityTypeConfiguration<TaxBandTable>
    {
        public void Configure(EntityTypeBuilder<TaxBandTable> builder)
        {
            builder.Property(x => x.TaxBand).HasColumnType("decimal(18,2)");
            builder.Property(x => x.TaxableAmt).HasColumnType("decimal(18,2)");
            builder.Property(x => x.Percentage).HasColumnType("decimal(18,2)");
        }
    }
}
