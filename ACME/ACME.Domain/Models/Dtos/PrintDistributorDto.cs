namespace ACME.Domain.Models.Dtos
{
    public class PrintDistributorDto
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required string APIEndPoint { get; set; }
        public required string APIKey { get; set; }
        public required string Status { get; set; }
        public required DateTimeOffset LastModifiedAtUtcNow { get; set; }
        public required string LastModifiedBy { get; set; }
    }
}
