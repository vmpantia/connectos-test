using ACME.Api.Contracts;
using ACME.Core.Queries.Models.Customers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ACME.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrintDistributorsController : BaseController
    {
        public PrintDistributorsController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        public async Task<IActionResult> GetPrintDistributorsAsync() =>
            await HandleRequestAsync(new GetPrintDistributorsQuery());

        [HttpGet("{printDistributorId}")]
        public async Task<IActionResult> GetPrintDistributorByIdAsync(Guid printDistributorId) =>
            await HandleRequestAsync(new GetPrintDistributorByIdQuery(printDistributorId));
    }
}
