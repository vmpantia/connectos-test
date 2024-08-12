using ACME.Domain.Models.Dtos;
using MediatR;

namespace ACME.Core.Queries.Models.Subscriptions
{
    public sealed class GetSubscriptionsQuery : IRequest<IEnumerable<SubscriptionDto>> { }
}
