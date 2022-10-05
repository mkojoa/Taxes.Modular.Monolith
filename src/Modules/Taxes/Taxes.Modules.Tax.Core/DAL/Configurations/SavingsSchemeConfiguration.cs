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
    internal class SavingsSchemeConfiguration : IEntityTypeConfiguration<SavingsScheme>
    {
        public void Configure(EntityTypeBuilder<SavingsScheme> builder)
        {

            builder.Property(x => x.UpperLimit).HasColumnType("decimal(18,2)");
            builder.Property(x => x.LowerLimit).HasColumnType("decimal(18,2)");
            builder.Property(x => x.Employer).HasColumnType("decimal(18,2)");
            builder.Property(x => x.Employee).HasColumnType("decimal(18,2)");
        }
    }
}
