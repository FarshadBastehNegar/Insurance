using Insurance.Domain.Entities.Common;

namespace CleanArchitecture.Domain.Common;

public abstract class BaseAuditableEntity<TId> : BaseEntity<TId>
{
    public DateTimeOffset Created { get; set; }
    public DateTimeOffset? LastModified { get; set; }
}
