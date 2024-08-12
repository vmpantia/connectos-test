using ACME.Domain.Models.Entities;

namespace ACME.Domain.Models.Dtos
{
    public class PrintRequestResultDto
    {
        public PrintRequestResultDto(Publication publication, DateTimeOffset requestAt)
        {
            PublicationId = publication.Id;
            PublicationName = publication.Name;
            PrintDistributorId = publication.PrintDistributor.Id;
            PrintDistributorName = publication.PrintDistributor.Name;
            PrintDistributorAPIEndpoint = publication.PrintDistributor.APIEndPoint;
            RequestSentAtUtcNow = requestAt;
        }

        public Guid PublicationId { get; init; }
        public string PublicationName { get; init; }
        public Guid PrintDistributorId { get; init; }
        public string PrintDistributorName { get; init; }
        public string PrintDistributorAPIEndpoint { get; init; }
        public DateTimeOffset RequestSentAtUtcNow { get; init; }
        public IEnumerable<SubscriptionSummaryDetailDto> Subscriptions { get; private set; }

        public void SetSubscriptionSummary(IEnumerable<SubscriptionSummaryDetailDto> subscription) => Subscription = subscription;
    }
}
