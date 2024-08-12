namespace ACME.Domain.Models.Dtos
{
    public class AddressDto
    {
        public required Guid Id { get; set; }
        public required Guid CustomerId { get; set; }
        public required string AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public required string City { get; set; }
        public required string ZipCode { get; set; }
        public required string State { get; set; }
        public required CountryDto Country { get; set; }
        public required string Status { get; set; }
        public required DateTimeOffset LastModifiedAtUtcNow { get; set; }
        public required string LastModifiedBy { get; set; }
    }
}
