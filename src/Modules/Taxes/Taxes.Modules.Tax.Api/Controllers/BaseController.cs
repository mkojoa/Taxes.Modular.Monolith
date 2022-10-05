using Microsoft.AspNetCore.Mvc;
using Taxes.Shared.Infrastructure.Api;

namespace Taxes.Modules.Tax.Api.Controllers;

[ApiController]
[Route("[controller]")]
[ProducesDefaultContentType]
internal abstract class BaseController : ControllerBase
{
    protected ActionResult<T> OkOrNotFound<T>(T model)
    {
        if (model is not null)
        {
            return Ok(model);
        }

        return NotFound();
    }
}