namespace ACME.Domain.Models.Dtos
{
    public class SubscriptionDto
    {
        public required Guid Id { get; set; }
        public required CustomerDto Customer { get; set; }
        public required AddressDto Address { get; set; }
        public required MagazineDto Magazine { get; set; }
        public required string Status { get; set; }
        public required DateTimeOffset LastModifiedAtUtcNow { get; set; }
        public required string LastModifiedBy { get; set; }
    }
}
