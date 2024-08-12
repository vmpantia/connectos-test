using ACME.Api.Contracts;
using ACME.Core.Queries.Models.Customers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ACME.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : BaseController
    {
        public CustomersController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        public async Task<IActionResult> GetCustomersAsync() => 
            await HandleRequestAsync(new GetPublicationsQuery());

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCustomerByIdAsync(Guid customerId) =>
            await HandleRequestAsync(new GetPublicationByIdQuery(customerId));
    }
}
