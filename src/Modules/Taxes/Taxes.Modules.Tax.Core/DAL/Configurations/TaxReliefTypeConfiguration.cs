using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxes.Modules.Tax.Core.Domain.Entities;

namespace Taxes.Modules.Tax.Core.DAL.Configurations
{
    internal class TaxReliefTypeConfiguration : IEntityTypeConfiguration<TaxReliefType>
    {
        public void Configure(EntityTypeBuilder<TaxReliefType> builder)
        {
            // builder.HasKey(x => x.Id);
            //builder.HasIndex(ugs => new { ugs.Id, ugs.Name }).IsUnique();
        }
    }
}
