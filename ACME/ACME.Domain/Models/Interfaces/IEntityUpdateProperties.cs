namespace ACME.Domain.Models.Interfaces
{
    public interface IEntityUpdateProperties
    {
        DateTimeOffset? UpdatedAtUtcNow { get; set; }
        string? UpdatedBy { get; set; }
    }
}
