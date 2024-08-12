using ACME.Domain.Models.Dtos;
using MediatR;

namespace ACME.Core.Queries.Models.Subscriptions
{
    public sealed record GetSubscriptionsByCustomerIdQuery(Guid CustomerId) : IRequest<IEnumerable<SubscriptionDto>> { }
}
