using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxes.Modules.Tax.Core.DTO;
using Taxes.Modules.Tax.Core.Queries;
using Taxes.Shared.Abstractions.Dispatchers;

namespace Taxes.Modules.Tax.Api.Controllers
{
    internal class TaxReliefController : BaseController
    {
        private const string Policy = "taxrelief";
        private readonly IDispatcher _dispatcher;

        public TaxReliefController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        // [HttpPost]
        // [SwaggerOperation("Create non cash")]
        // [ProducesResponseType(StatusCodes.Status204NoContent)]
        // [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // public async Task<ActionResult> Post(CreateNonCash command)
        // {
        //     command.Bind(x => x.UserId, _context.Identity.Id);
        //     await _dispatcher.SendAsync(command);
        //     return NoContent();
        // }

        // [HttpGet("{countryCode}")]
        // [SwaggerOperation("Get non cash by country")]
        // [ProducesResponseType(StatusCodes.Status200OK)]
        // [ProducesResponseType(StatusCodes.Status404NotFound)]
        // [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        // [ProducesResponseType(StatusCodes.Status403Forbidden)]
        // public async Task<ActionResult<IEnumerable<NonCashDto>>> GetAsync(string countryCode)
        //    => OkOrNotFound(await _dispatcher.QueryAsync(new GetNonCashs { CountryCode = countryCode }));


        // [HttpGet("{id:guid}")]
        // [SwaggerOperation("Get non cash")]
        // [ProducesResponseType(StatusCodes.Status200OK)]
        // [ProducesResponseType(StatusCodes.Status404NotFound)]
        // [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        // [ProducesResponseType(StatusCodes.Status403Forbidden)]
        // public async Task<ActionResult<NonCashDto>> GetAsync(Guid id)
        //    => OkOrNotFound(await _dispatcher.QueryAsync(new GetNonCash { Id = id }));

        // [HttpGet("")]
        // [SwaggerOperation("browse non cash")]
        // [ProducesResponseType(StatusCodes.Status200OK)]
        // [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        // [ProducesResponseType(StatusCodes.Status403Forbidden)]
        // public async Task<ActionResult<Paged<NonCashDto>>> BrowseAsync([FromQuery] BrowseNonCash query)
        //     => Ok(await _dispatcher.QueryAsync(query));






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
