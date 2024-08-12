namespace ACME.Domain.Models.Dtos
{
    public class SubscriptionSummaryDetailDto
    {
        public required Guid CustomerId { get; set; }
        public required string CustomerName { get; set; }

        public required Guid CustomerAddressId { get; set; }
        public required string CustomerAddress { get; set; }

        public required Guid SubscriptionId { get; set; }
        public required Guid MagazineId { get; set; }
        public required string MagazineName { get; set; }

        public required Guid CountryId { get; set; }
        public required string CountryName { get; set; }
    }
}
