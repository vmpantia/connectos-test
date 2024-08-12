using ACME.Domain.Models.Enums;
using ACME.Domain.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ACME.Domain.Models.Entities
{
    public class PrintDistributor : IEntity
    {
        [Key]
        public required Guid Id { get; set; }

        public required Guid PublicationId { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required string APIEndPoint { get; set; }
        public required string APIKey { get; set; }

        public required Status Status { get; set; }
        public required DateTimeOffset CreatedAtUtcNow { get; set; }
        public required string CreatedBy { get; set; }
        public DateTimeOffset? UpdatedAtUtcNow { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTimeOffset? DeletedAtUtcNow { get; set; }
        public string? DeletedBy { get; set; }

        public virtual Publication Publication { get; set; }
    }
}
