using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taxes.Modules.Tax.Core.Domain.Entities;

namespace Taxes.Modules.Tax.Core.DAL.Configurations
{
    internal class CalculationRuleConfiguration : IEntityTypeConfiguration<CalculationRule>
    {
        public void Configure(EntityTypeBuilder<CalculationRule> builder)
        {
        }
    }
}
