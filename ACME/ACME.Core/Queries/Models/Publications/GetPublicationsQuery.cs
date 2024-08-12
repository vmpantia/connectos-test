using ACME.Domain.Models.Dtos;
using MediatR;

namespace ACME.Core.Queries.Models.Customers
{
    public sealed class GetPublicationsQuery : IRequest<IEnumerable<PublicationDto>> { }
}
