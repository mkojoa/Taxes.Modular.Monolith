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
    internal class NonCashController : BaseController
    {
        private const string Policy = "noncash";
        private readonly IDispatcher _dispatcher;

        public NonCashController(IDispatcher dispatcher)
        { 
            _dispatcher = dispatcher;


        }

        [HttpGet("Type/{countryCode}")]
        [SwaggerOperation("Get noncash by country code")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<NonCashTypeDto>>> GetAsync(string countryCode)
            => OkOrNotFound(await _dispatcher.QueryAsync(new GetNonCashType { CountryCode = countryCode }));

        [HttpGet("Type")]
        [SwaggerOperation("get non cash types")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<NonCashTypeDto>>> GetAllAsync()
            => Ok(await _dispatcher.QueryAsync(new GetNonCashTypes { }));


    }
}
