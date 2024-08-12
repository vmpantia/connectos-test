using ACME.Api.Contracts;
using ACME.Core.Queries.Models.Customers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ACME.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicationsController : BaseController
    {
        public PublicationsController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        public async Task<IActionResult> GetPublicationsAsync() =>
            await HandleRequestAsync(new GetPublicationsQuery());

        [HttpGet("{publicationId}")]
        public async Task<IActionResult> GetPublicationByIdAsync(Guid publicationId) =>
            await HandleRequestAsync(new GetPublicationByIdQuery(publicationId));

        [HttpGet("PrintDistributors/{printDistributorId}")]
        public async Task<IActionResult> GetPublicationsByPrintDistributorIdAsync(Guid printDistributorId) =>
            await HandleRequestAsync(new GetPublicationsByPrintDistributorIdQuery(printDistributorId));
    }
}
