namespace ACME.Domain.Models.Dtos
{
    public class PublicationDto
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required CountryDto Country { get; set; }
        public required PrintDistributorDto PrintDistributor { get; set; }
        public required string Status { get; set; }
        public required DateTimeOffset LastModifiedAtUtcNow { get; set; }
        public required string LastModifiedBy { get; set; }
    }
}
