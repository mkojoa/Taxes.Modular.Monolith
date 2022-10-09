using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxes.Modules.Tax.Core.Commands;
using Taxes.Modules.Tax.Core.DTO;
using Taxes.Modules.Tax.Core.Queries;
using Taxes.Shared.Abstractions.Contexts;
using Taxes.Shared.Abstractions.Dispatchers;
using Taxes.Shared.Abstractions.Queries;
using Taxes.Shared.Infrastructure.Api;

namespace Taxes.Modules.Tax.Api.Controllers
{
    internal class TaxReliefController : BaseController
    {
        private const string Policy = "taxrelief";
        private readonly IDispatcher _dispatcher;
        private readonly IContext _context;

        public TaxReliefController(IDispatcher dispatcher, IContext context)
        {
            _dispatcher = dispatcher;
            _context = context;
        }

        [HttpPost]
        [SwaggerOperation("Create tax relief")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post(CreateTaxRelief command)
        {
            command.Bind(x => x.UserId, _context.Identity.Id);
            await _dispatcher.SendAsync(command);
            return NoContent();
        }

        [HttpGet("{countryCode}")]
        [SwaggerOperation("Get tax relief by country")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<TaxReliefDto>>> Get222Async(string countryCode)
           => OkOrNotFound(await _dispatcher.QueryAsync(new GetTaxReliefs { CountryCode = countryCode }));


        [HttpGet("{id:guid}")]
        [SwaggerOperation("Get tax relief")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<TaxReliefDto>> Get22Async(Guid id)
           => OkOrNotFound(await _dispatcher.QueryAsync(new GetTaxRelief { Id = id }));

        [HttpGet("")]
        [SwaggerOperation("browse tax relief")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<Paged<TaxReliefDto>>> BrowseAsync([FromQuery] BrowseTaxRelief query)
            => Ok(await _dispatcher.QueryAsync(query));

 




        [HttpGet("Type/{countryCode}")]
        [SwaggerOperation("Get tax relief type by country code")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<TaxReliefTypeDto>>> GetAsync(string countryCode)
            => OkOrNotFound(await _dispatcher.QueryAsync(new GetTaxReliefType { CountryCode = countryCode }));

        [HttpGet("Type")]
        [SwaggerOperation("get tax relief type")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<TaxReliefTypeDto>>> GetAllAsync()
            => Ok(await _dispatcher.QueryAsync(new GetTaxReliefTypes { }));


    }
}
