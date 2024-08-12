using ACME.Core.Queries.Models.Customers;
using ACME.Domain.Contracts;
using ACME.Domain.Exceptions;
using ACME.Domain.Models.Dtos;
using AutoMapper;
using MediatR;

namespace ACME.Core.Queries.Handlers
{
    public sealed class CustomerQueryHandler : 
        IRequestHandler<GetCustomersQuery, IEnumerable<CustomerDto>>,
        IRequestHandler<GetCustomerByIdQuery, CustomerDto>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public CustomerQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository= customerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerDto>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.GetCustomersFullInformationAsync(cancellationToken);
            
            // Check if the customers is NULL
            if(customers is null) throw new ArgumentNullException(nameof(customers));

            // Map entity to dto
            var result = _mapper.Map<IEnumerable<CustomerDto>>(customers);
            return result;
        }

        public async Task<CustomerDto> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.GetCustomersFullInformationAsync(data => data.Id == request.CustomerId,
                                                                                       cancellationToken);

            // Check if the customer exist in the database
            if(customers is null || !customers.Any())
                throw new NotFoundException($"Customer with an Id {request.CustomerId} is not found in the database.");

            // Map entity to dto
            var result = _mapper.Map<CustomerDto>(customers.First());
            return result;
        }
    }
}
