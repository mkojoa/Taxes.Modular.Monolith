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
    internal class NonCashConfiguration : IEntityTypeConfiguration<NonCash>
    {
        public void Configure(EntityTypeBuilder<NonCash> builder)
        {

            builder.Property(x => x.Ceiling).HasColumnType("decimal(18,2)");
            builder.Property(x => x.Rate).HasColumnType("decimal(18,2)");
        }
    }
}
