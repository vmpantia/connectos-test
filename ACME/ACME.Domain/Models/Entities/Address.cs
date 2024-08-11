using ACME.Domain.Models.Enums;
using ACME.Domain.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ACME.Domain.Models.Entities
{
    public class Address : IEntity
    {
        [Key]
        public required Guid Id { get; set; }

        public required Guid CustomerId { get; set; }
        public required string AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public required string City { get; set; }
        public required string ZipCode { get; set; }
        public required string State { get; set; }
        public required Guid CountryId { get; set; }

        public required Status Status { get; set; }
        public required DateTimeOffset CreatedAtUtcNow { get; set; }
        public required string CreatedBy { get; set; }
        public DateTimeOffset? UpdatedAtUtcNow { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTimeOffset? DeletedAtUtcNow { get; set; }
        public string? DeletedBy { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Country Country { get; set; }
        public virtual Subscription Subscription { get; set; }
    }
}
