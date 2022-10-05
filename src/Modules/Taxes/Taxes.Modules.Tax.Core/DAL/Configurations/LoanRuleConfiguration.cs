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
    internal class LoanRuleConfiguration : IEntityTypeConfiguration<LoanRule>
    {
        public void Configure(EntityTypeBuilder<LoanRule> builder)
        {
            builder.Property(x => x.StatutoryRate).HasColumnType("decimal(18,2)");
            builder.Property(x => x.GearingRatio).HasColumnType("decimal(18,2)");
        }
    }
}
