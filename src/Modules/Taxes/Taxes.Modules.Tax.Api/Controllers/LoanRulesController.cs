using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taxes.Modules.Tax.Core.DTO;
using Taxes.Modules.Tax.Core.Queries;
using Taxes.Shared.Abstractions.Contexts;
using Taxes.Shared.Abstractions.Dispatchers;
using Taxes.Shared.Abstractions.Queries;

namespace Taxes.Modules.Tax.Api.Controllers
{
    internal class LoanRulesController : BaseController
    {
        private const string Policy = "loanrules";
        private readonly IDispatcher _dispatcher;
        private readonly IContext _context;


        public LoanRulesController(IDispatcher dispatcher,IContext context)
        {
            _dispatcher = dispatcher;
            _context = context;


        }

        // [HttpPost]
        // [SwaggerOperation("Create Loans")]
        // [ProducesResponseType(StatusCodes.Status204NoContent)]
        // [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // public async Task<ActionResult> Post(CreateLoan command)
        // {
        //     command.Bind(x => x.UserId, _context.Identity.Id);
        //     await _dispatcher.SendAsync(command);
        //     return NoContent();
        // }

        [HttpGet("{countryCode}")]
        [SwaggerOperation("Get loan by country")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<LoanDto>>> Get2Async(string countryCode)
           => OkOrNotFound(await _dispatcher.QueryAsync(new GetLoans { CountryCode = countryCode }));


        [HttpGet("{id:guid}")]
        [SwaggerOperation("Get loan")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<LoanDto>> Get22Async(Guid id)
           => OkOrNotFound(await _dispatcher.QueryAsync(new GetLoan { Id = id }));

        [HttpGet("")]
        [SwaggerOperation("browse loan")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<Paged<LoanDto>>> BrowseAsync([FromQuery] BrowseLoan query)
            => Ok(await _dispatcher.QueryAsync(query));
    }
}
