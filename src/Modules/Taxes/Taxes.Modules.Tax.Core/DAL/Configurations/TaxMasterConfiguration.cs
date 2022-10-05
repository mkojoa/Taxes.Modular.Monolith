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
    internal class TaxMasterConfiguration : IEntityTypeConfiguration<TaxMaster>
    {
        public void Configure(EntityTypeBuilder<TaxMaster> builder)
        {


        }
    }
}
