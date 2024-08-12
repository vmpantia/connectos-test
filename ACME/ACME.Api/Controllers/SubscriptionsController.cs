using ACME.Api.Contracts;
using ACME.Core.Queries.Models.Subscriptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ACME.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionsController : BaseController
    {
        public SubscriptionsController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        public async Task<IActionResult> GetSubscriptionsAsync() =>
            await HandleRequestAsync(new GetSubscriptionsQuery());

        [HttpGet("{subscriptionId}")]
        public async Task<IActionResult> GetSubscriptionByIdAsync(Guid subscriptionId) =>
            await HandleRequestAsync(new GetSubscriptionByIdQuery(subscriptionId));

        [HttpGet("Customers/{customerId}")]
        public async Task<IActionResult> GetSubscriptionsByCustomerIdAsync(Guid customerId) =>
            await HandleRequestAsync(new GetSubscriptionsByCustomerIdQuery(customerId));

        [HttpGet("Publications/{publicationId}")]
        public async Task<IActionResult> GetSubscriptionsByPublicationIdASync(Guid publicationId) =>
            await HandleRequestAsync(new GetSubscriptionsByPublicationIdQuery(publicationId));
    }
}
