namespace ACME.Domain.Models.Dtos
{
    public class CustomerDto
    {
        public required Guid Id { get; set; }
        public required string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public required string Status { get; set; }
        public required IEnumerable<AddressDto> Addresses { get; set; }
        public required int NoOfActiveSubscriptions { get; set; }

        public required DateTimeOffset LastModifiedAtUtcNow { get; set; }
        public required string LastModifiedBy { get; set; }
    }
}
