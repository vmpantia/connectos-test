using ACME.Domain.Models.Enums;
using ACME.Domain.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ACME.Domain.Models.Entities
{
    public class Subscription : IEntity
    {
        [Key]
        public required Guid Id { get; set; }

        public required Guid CustomerId { get; set; }
        public required Guid AddressId { get; set; }
        public required Guid MagazineId { get; set; }

        public required Status Status { get; set; }
        public required DateTimeOffset CreatedAtUtcNow { get; set; }
        public required string CreatedBy { get; set; }
        public DateTimeOffset? UpdatedAtUtcNow { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTimeOffset? DeletedAtUtcNow { get; set; }
        public string? DeletedBy { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Address Address { get; set; }
        public virtual Magazine Magazine { get; set; }
    }
}
