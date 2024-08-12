using ACME.Domain.Models.Dtos;
using MediatR;

namespace ACME.Core.Commands.Models
{
    public sealed class SendPrintRequestForActiveSubscriptionsCommand : IRequest<IEnumerable<PrintRequestResultDto>> { }
}
