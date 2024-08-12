using ACME.Domain.Models.Dtos;
using MediatR;

namespace ACME.Core.Queries.Models.Subscriptions
{
    public sealed record GetSubscriptionsByPublicationIdQuery(Guid PublicationId) : IRequest<IEnumerable<SubscriptionDto>> { }
}
