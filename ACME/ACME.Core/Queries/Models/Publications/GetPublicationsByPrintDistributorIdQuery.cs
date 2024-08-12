using ACME.Domain.Models.Dtos;
using MediatR;

namespace ACME.Core.Queries.Models.Customers
{
    public sealed record GetPublicationsByPrintDistributorIdQuery(Guid PrintDistributorId) : IRequest<IEnumerable<PublicationDto>> { }
}
