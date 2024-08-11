namespace ACME.Domain.Models.Interfaces
{
    public interface IEntityCreateProperties
    {
        DateTimeOffset CreatedAtUtcNow { get; set; }
        string CreatedBy { get; set; }
    }
}
