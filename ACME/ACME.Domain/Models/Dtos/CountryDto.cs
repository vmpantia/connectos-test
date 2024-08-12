namespace ACME.Domain.Models.Dtos
{
    public class CountryDto
    {
        public required Guid Id { get; set; }
        public required string Code { get; set; }
        public required string Name { get; set; }
        public required string Status { get; set; }
        public required DateTimeOffset LastModifiedAtUtcNow { get; set; }
        public required string LastModifiedBy { get; set; }
    }
}
