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
    internal class TaxTableConfiguration : IEntityTypeConfiguration<TaxTable>
    {
        public void Configure(EntityTypeBuilder<TaxTable> builder)
        {


        }
    }
}
