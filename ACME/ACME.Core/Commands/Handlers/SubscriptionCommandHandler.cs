using ACME.Core.Commands.Models;
using ACME.Domain.Contracts;
using ACME.Domain.Models.Dtos;
using ACME.Domain.Models.Enums;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ACME.Core.Commands.Handlers
{
    public class SubscriptionCommandHandler :
        IRequestHandler<SendPrintRequestForActiveSubscriptionsCommand, IEnumerable<PrintRequestResultDto>>
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IPublicationRepository _publicationRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<SubscriptionCommandHandler> _logger;
        public SubscriptionCommandHandler(ISubscriptionRepository subscriptionRepository, IPublicationRepository publicationRepository, IMapper mapper, ILogger<SubscriptionCommandHandler> logger)
        {
            _subscriptionRepository = subscriptionRepository;
            _publicationRepository = publicationRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<PrintRequestResultDto>> Handle(SendPrintRequestForActiveSubscriptionsCommand request, CancellationToken cancellationToken)
        {
            var result = new List<PrintRequestResultDto>();

            // Get active subscriptions
            var subscriptions = await _subscriptionRepository.GetSubscriptionsFullInformationAsync(data => data.Status == Status.Enabled,
                                                                                                   cancellationToken);

            // Check if any active subscriptions
            if (subscriptions is null || !subscriptions.Any())
                throw new Exception("No active subscriptions to be processed at this moment.");

            // Grouped subscription into customer address country
            var subscriptionsByCountries = subscriptions.GroupBy(data => data.Address.CountryId);

            foreach(var subscriptionsByCountry in subscriptionsByCountries)
            {
                var publications = await _publicationRepository.GetPublicationsFullInformationAsync(data => data.CountryId == subscriptionsByCountry.Key,
                                                                                                    cancellationToken);

                // Check if any publications within the country
                if(publications is null || !publications.Any())
                {
                    _logger.LogWarning($"No publication on the country {subscriptionsByCountry.Key}");
                    continue;
                }

                // Create print request result
                var printRequestResult = new PrintRequestResultDto(publications.First(), DateTimeOffset.UtcNow);
                var summaries = _mapper.Map<IEnumerable<SubscriptionSummaryDetailDto>>(subscriptionsByCountry);
                printRequestResult.SetSubscriptionSummary(summaries);

                result.Add(printRequestResult);
            }

            return result;
        }
    }
}
