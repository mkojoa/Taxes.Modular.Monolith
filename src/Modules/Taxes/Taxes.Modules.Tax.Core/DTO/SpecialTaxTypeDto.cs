﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxes.Modules.Tax.Core.DTO
{
    internal class SpecialTaxTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }
    }
}
