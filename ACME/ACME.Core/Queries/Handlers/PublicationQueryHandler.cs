using ACME.Core.Queries.Models.Customers;
using ACME.Domain.Contracts;
using ACME.Domain.Exceptions;
using ACME.Domain.Models.Dtos;
using AutoMapper;
using MediatR;

namespace ACME.Core.Queries.Handlers
{
    public sealed class PublicationQueryHandler : 
        IRequestHandler<GetPublicationsQuery, IEnumerable<PublicationDto>>,
        IRequestHandler<GetPublicationByIdQuery, PublicationDto>,
        IRequestHandler<GetPublicationsByPrintDistributorIdQuery, IEnumerable<PublicationDto>>
    {
        private readonly IPublicationRepository _publicationRepository;
        private readonly IMapper _mapper;
        public PublicationQueryHandler(IPublicationRepository publicationRepository, IMapper mapper)
        {
            _publicationRepository = publicationRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PublicationDto>> Handle(GetPublicationsQuery request, CancellationToken cancellationToken)
        {
            var publications = await _publicationRepository.GetPublicationsFullInformationAsync(cancellationToken);

            // Check if the publications is NULL
            if (publications is null) throw new ArgumentNullException(nameof(publications));

            // Map entity to dto
            var result = _mapper.Map<IEnumerable<PublicationDto>>(publications);
            return result;
        }

        public async Task<PublicationDto> Handle(GetPublicationByIdQuery request, CancellationToken cancellationToken)
        {
            var publications = await _publicationRepository.GetPublicationsFullInformationAsync(data => data.Id == request.PublicationId,
                                                                                             cancellationToken);

            // Check if the publication exist in the database
            if (publications is null || !publications.Any())
                throw new NotFoundException($"Publication with an Id {request.PublicationId} is not found in the database.");

            // Map entity to dto
            var result = _mapper.Map<PublicationDto>(publications.First());
            return result;
        }

        public async Task<IEnumerable<PublicationDto>> Handle(GetPublicationsByPrintDistributorIdQuery request, CancellationToken cancellationToken)
        {
            var publications = await _publicationRepository.GetPublicationsFullInformationAsync(data => data.PrintDistributor.Id == request.PrintDistributorId,
                                                                                                cancellationToken);

            // Check if the subscriptions is NULL
            if (publications is null) throw new ArgumentNullException(nameof(publications));

            // Map entity to dto
            var result = _mapper.Map<IEnumerable<PublicationDto>>(publications);
            return result;
        }
    }
}
