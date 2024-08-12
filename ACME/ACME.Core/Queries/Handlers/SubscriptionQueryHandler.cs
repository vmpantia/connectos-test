using ACME.Core.Queries.Models.Subscriptions;
using ACME.Domain.Contracts;
using ACME.Domain.Exceptions;
using ACME.Domain.Models.Dtos;
using ACME.Domain.Models.Entities;
using AutoMapper;
using MediatR;

namespace ACME.Core.Queries.Handlers
{
    public sealed class SubscriptionQueryHandler :
        IRequestHandler<GetSubscriptionsQuery, IEnumerable<SubscriptionDto>>,
        IRequestHandler<GetSubscriptionByIdQuery, SubscriptionDto>,
        IRequestHandler<GetSubscriptionsByCustomerIdQuery, IEnumerable<SubscriptionDto>>,
        IRequestHandler<GetSubscriptionsByPublicationIdQuery, IEnumerable<SubscriptionDto>>
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IPublicationRepository _publicationRepository;
        private readonly IMapper _mapper;
        public SubscriptionQueryHandler(ISubscriptionRepository subscriptionRepository, IPublicationRepository publicationRepository, IMapper mapper)
        {
            _subscriptionRepository = subscriptionRepository;
            _publicationRepository = publicationRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SubscriptionDto>> Handle(GetSubscriptionsQuery request, CancellationToken cancellationToken)
        {
            var subscriptions = await _subscriptionRepository.GetSubscriptionsFullInformationAsync(cancellationToken);

            // Check if the subscriptions is NULL
            if (subscriptions is null) throw new ArgumentNullException(nameof(subscriptions));

            // Map entity to dto
            var result = _mapper.Map<IEnumerable<SubscriptionDto>>(subscriptions);
            return result;
        }

        public async Task<SubscriptionDto> Handle(GetSubscriptionByIdQuery request, CancellationToken cancellationToken)
        {
            var subscriptions = await _subscriptionRepository.GetSubscriptionsFullInformationAsync(data => data.Id == request.SubscriptionId,
                                                                                                   cancellationToken);

            // Check if the subscription exist in the database
            if (subscriptions is null || !subscriptions.Any())
                throw new NotFoundException($"Subscription with an Id {request.SubscriptionId} is not found in the database.");

            // Map entity to dto
            var result = _mapper.Map<SubscriptionDto>(subscriptions.First());
            return result;
        }

        public async Task<IEnumerable<SubscriptionDto>> Handle(GetSubscriptionsByCustomerIdQuery request, CancellationToken cancellationToken)
        {
            var subscriptions = await _subscriptionRepository.GetSubscriptionsFullInformationAsync(data => data.CustomerId == request.CustomerId,
                                                                                                   cancellationToken);

            // Check if the subscriptions is NULL
            if (subscriptions is null) throw new ArgumentNullException(nameof(subscriptions));

            // Map entity to dto
            var result = _mapper.Map<IEnumerable<SubscriptionDto>>(subscriptions);
            return result;
        }

        public async Task<IEnumerable<SubscriptionDto>> Handle(GetSubscriptionsByPublicationIdQuery request, CancellationToken cancellationToken)
        {
            // Check and get publication in database
            if (!_publicationRepository.IsExist(data => data.Id == request.PublicationId, out Publication publication))
                throw new NotFoundException($"Publication with an Id {request.PublicationId} is not found in the database.");

            var subscriptions = await _subscriptionRepository.GetSubscriptionsFullInformationAsync(data => data.Address.CountryId == publication.CountryId,
                                                                                                   cancellationToken);

            // Check if the subscriptions is NULL
            if (subscriptions is null) throw new ArgumentNullException(nameof(subscriptions));

            // Map entity to dto
            var result = _mapper.Map<IEnumerable<SubscriptionDto>>(subscriptions);
            return result;
        }
    }
}
