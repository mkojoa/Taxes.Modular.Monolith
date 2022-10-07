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
    internal class SavingSchemeController : BaseController
    {
        private const string Policy = "savingscheme";
        private readonly IDispatcher _dispatcher;
        private readonly IContext _context;


        public SavingSchemeController(IDispatcher dispatcher,IContext context)
        {
            _dispatcher = dispatcher;
            _context = context;


        }

        [HttpPost]
        [SwaggerOperation("Create Saving Scheme")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post(CreateSavingScheme command)
        {
            command.Bind(x => x.UserId, _context.Identity.Id);
            await _dispatcher.SendAsync(command);
            return NoContent();
        }

        [HttpGet("{countryCode}")]
        [SwaggerOperation("Get SavingScheme by country")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<SavingSchemeDto>>> Get2Async(string countryCode)
           => OkOrNotFound(await _dispatcher.QueryAsync(new GetSavingSchemes { CountryCode = countryCode }));


        [HttpGet("{id:guid}")]
        [SwaggerOperation("Get Saving Scheme")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<SavingSchemeDto>> Get22Async(Guid id)
           => OkOrNotFound(await _dispatcher.QueryAsync(new GetSavingScheme { Id = id }));

        [HttpGet("")]
        [SwaggerOperation("browse saving scheme")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<Paged<SavingSchemeDto>>> BrowseAsync([FromQuery] BrowseSavingScheme query)
            => Ok(await _dispatcher.QueryAsync(query));




        [HttpGet("Type/{countryCode}")]
        [SwaggerOperation("Get saving scheme type by country code")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<SavingSchemeTypeDto>>> GetAsync(string countryCode)
            => OkOrNotFound(await _dispatcher.QueryAsync(new GetSavingSchemeType { CountryCode = countryCode }));

        [HttpGet("Type")]
        [SwaggerOperation("get saving scheme type")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<SavingSchemeTypeDto>>> GetAllAsync()
            => Ok(await _dispatcher.QueryAsync(new GetSavingSchemeTypes { }));


    }
}
