using ACME.Domain.Models.Enums;

namespace ACME.Domain.Models.Interfaces
{
    public interface IEntity : IEntityCreateProperties,
                               IEntityUpdateProperties,
                               IEntityDeleteProperties
    {
        Guid Id { get; set; }
        Status Status { get; set; }
    }
}
