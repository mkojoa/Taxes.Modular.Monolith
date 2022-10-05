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
    internal class CountryController : BaseController
    {
        private const string Policy = "countries";
        private readonly IDispatcher _dispatcher;

        public CountryController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;


        }

        [HttpGet("{code}")]
        [SwaggerOperation("Get countries by code")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<CountryDto>> GetAsync(string code)
            => OkOrNotFound(await _dispatcher.QueryAsync(new GetCountry { Code = code }));

        [HttpGet]
        [SwaggerOperation("get countries")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<CountryDto>>> GetAllAsync()
            => Ok(await _dispatcher.QueryAsync(new GetCountries { }));


    }
}
