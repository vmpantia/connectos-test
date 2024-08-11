namespace ACME.Domain.Models.Interfaces
{
    public interface IEntityDeleteProperties
    {
        DateTimeOffset? DeletedAtUtcNow { get; set; }
        string? DeletedBy { get; set; }
    }
}
