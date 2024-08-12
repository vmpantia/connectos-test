using ACME.Core.Queries.Models.Customers;
using ACME.Domain.Contracts;
using ACME.Domain.Exceptions;
using ACME.Domain.Models.Dtos;
using AutoMapper;
using MediatR;

namespace ACME.Core.Queries.Handlers
{
    public sealed class PrintDistributorQueryHandler : 
        IRequestHandler<GetPrintDistributorsQuery, IEnumerable<PrintDistributorDto>>,
        IRequestHandler<GetPrintDistributorByIdQuery, PrintDistributorDto>
    {
        private readonly IPrintDistributorRepository _printDistributorRepository;
        private readonly IMapper _mapper;
        public PrintDistributorQueryHandler(IPrintDistributorRepository printDistributorRepository, IMapper mapper)
        {
            _printDistributorRepository = printDistributorRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PrintDistributorDto>> Handle(GetPrintDistributorsQuery request, CancellationToken cancellationToken)
        {
            var distributors = await _printDistributorRepository.GetPrintDistributorsFullInformationAsync(cancellationToken);

            // Check if the publications is NULL
            if (distributors is null) throw new ArgumentNullException(nameof(distributors));

            // Map entity to dto
            var result = _mapper.Map<IEnumerable<PrintDistributorDto>>(distributors);
            return result;
        }

        public async Task<PrintDistributorDto> Handle(GetPrintDistributorByIdQuery request, CancellationToken cancellationToken)
        {
            var distributors = await _printDistributorRepository.GetPrintDistributorsFullInformationAsync(data => data.Id == request.PrintDistributorId,
                                                                                                          cancellationToken);

            // Check if the print distributor exist in the database
            if (distributors is null || !distributors.Any())
                throw new NotFoundException($"Print Distributor with an Id {request.PrintDistributorId} is not found in the database.");

            // Map entity to dto
            var result = _mapper.Map<PrintDistributorDto>(distributors.First());
            return result;
        }
    }
}
