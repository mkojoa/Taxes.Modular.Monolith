using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Taxes.Shared.Infrastructure;
using System;
using System.Collections.Generic;
using Taxes.Modules.Tax.Core.Domain.Entities;
using Taxes.Shared.Abstractions.Kernel.Entites;

namespace Taxes.Modules.Tax.Core.DAL;

internal sealed class TaxesInitializer : IInitializer
{


    private readonly TaxesDbContext _dbContext;
    private readonly ILogger<TaxesInitializer> _logger;

    public TaxesInitializer(TaxesDbContext dbContext, ILogger<TaxesInitializer> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task InitAsync()
    {
        bool seed = false;
        if (!await _dbContext.NonCashTypes.AnyAsync())
        {
            await AddNonCashTypesAsync();
            seed = true;

        }

        if (!await _dbContext.Countries.AnyAsync())
        {
            await AddCountriesAsync();
            seed = true;

        }
        if (!await _dbContext.SavingsSchemeTypes.AnyAsync())
        {
            await AddSavingsSchemeTypesAsync();
            seed = true;

        }
        if (!await _dbContext.SpecialTaxTypes.AnyAsync())
        {
            await AddSpecialTaxTypesAsync();
            seed = true;
        }
        if (!await _dbContext.TaxReliefType.AnyAsync())
        {
            await AddTaxReliefTypeAsync();
            seed = true;
        }
        if (seed)
            await _dbContext.SaveChangesAsync();
    }

    private async Task AddNonCashTypesAsync()
    {
        await _dbContext.NonCashTypes.AddAsync(new NonCashType
        {
            //Id = 1,
            Name = "Accommodation with furnishing",
            CountryCode = "GH",
            CreatedAt = DateTime.Now,
        });
        await _dbContext.NonCashTypes.AddAsync(new NonCashType
        {
            //Id = 2,
            Name = "Accommodation only",
            CountryCode = "GH",
            CreatedAt = DateTime.Now,
        });
        await _dbContext.NonCashTypes.AddAsync(new NonCashType
        {
            //Id = 3,
            Name = "Furnishing only",
            CountryCode = "GH",
            CreatedAt = DateTime.Now,
        });
        await _dbContext.NonCashTypes.AddAsync(new NonCashType
        {
            //Id = 4,
            Name = "Shared Accommodation",
            CountryCode = "GH",
            CreatedAt = DateTime.Now,
        });
        await _dbContext.NonCashTypes.AddAsync(new NonCashType
        {
            //Id = 5,
            Name = "Driver and vehicle with fuel",
            CountryCode = "GH",
            CreatedAt = DateTime.Now,
        });
        await _dbContext.NonCashTypes.AddAsync(new NonCashType
        {
            //Id = 6,
            Name = "Vehicle with fuel",
            CountryCode = "GH",
            CreatedAt = DateTime.Now,
        });
        await _dbContext.NonCashTypes.AddAsync(new NonCashType
        {
            //Id = 7,
            Name = "Vehicle only",
            CountryCode = "GH",
            CreatedAt = DateTime.Now,
        });
        await _dbContext.NonCashTypes.AddAsync(new NonCashType
        {
            //Id = 8,
            Name = "Fuel only",
            CountryCode = "GH",
            CreatedAt = DateTime.Now,
        });

        _logger.LogInformation("Initialized NonCashType.");
    }

    private async Task AddSavingsSchemeTypesAsync()
    {
        await _dbContext.SavingsSchemeTypes.AddAsync(new SavingsSchemeType
        {
            Id = new Guid("0391a3c5-8f3c-4581-8400-845e4d34b2a2"),
            Name = "Defined Benefit Basic N.S.S.S",
            Code = "DBBNSSS",
            CountryCode = "GH",
            SchemeCap = 10,
            StatutoryFund = 1
        });
        await _dbContext.SavingsSchemeTypes.AddAsync(new SavingsSchemeType
        {
            Id = new Guid("c4c66994-7703-4c74-8f1f-2ac6359e099b"),
            Code = "OPS",
            Name = "Occupational Pension Scheme",
            CountryCode = "GH",
            SchemeCap = 10,
            StatutoryFund = 1
        });
        await _dbContext.SavingsSchemeTypes.AddAsync(new SavingsSchemeType
        {
            Id = new Guid("7d906990-b3d9-4647-a974-8f558bc41720"),
            Code = "PPS",
            Name = "Personal Pension Scheme",
            CountryCode = "GH",
            SchemeCap = 10,
            StatutoryFund = 1
        });
        await _dbContext.SavingsSchemeTypes.AddAsync(new SavingsSchemeType
        {
            Id = new Guid("006AA625-4697-4A2C-B399-2D28845AF84F"),
            Code = "OTHER",
            Name = "Other Fund",
            CountryCode = "GH",
            SchemeCap = 10,
            StatutoryFund = 1
        });
        _logger.LogInformation("Initialized Savings Scheme Types.");
    }

    private async Task AddSpecialTaxTypesAsync() 
    {
        var taxType = new List<SpecialTaxType>
        {
            new SpecialTaxType
            {
                //Id = 1,
                Name = "BNS",
                CountryCode = "GH",
                CreatedAt = DateTime.Now
            },
            new SpecialTaxType
            {
                //Id = 2,
                Name = "OTS",
                CountryCode = "GH",
                CreatedAt = DateTime.Now
            }
        };
        await _dbContext.SpecialTaxTypes.AddRangeAsync(taxType);

        _logger.LogInformation("Initialized SpecialTaxType.");
    }

    private async Task AddTaxReliefTypeAsync()
    {
        var taxType = new List<TaxReliefType>
        {
            new TaxReliefType
            {
                //Id = 1,
                Name = "Covid Relief",
                CountryCode = "GH",
                CreatedAt = DateTime.Now
            },
            new TaxReliefType
            {
                //Id = 2,
                Name = "MRG Type",
                CountryCode = "GH",
                CreatedAt = DateTime.Now
            }
        };
        await _dbContext.TaxReliefType.AddRangeAsync(taxType);

        _logger.LogInformation("Initialized SpecialTaxType.");
    }

    private async Task AddCountriesAsync()
    {
        await _dbContext.Countries.AddRangeAsync(GenericData.Countries);

        _logger.LogInformation("Initialized SpecialTaxType.");
    }
}