using Insurance.Domain.Entities.Common;
using Insurance.Domain.Enums;

namespace Insurance.Domain.Entities;

public class Coverage : BaseEntity<int>
{
    public int RequestId { get; set; }
    public CoverageEnum CoverageType { get; private set; }
    public decimal Amount { get; private set; }

    public Coverage(CoverageEnum coverageType, decimal amount)
    {
        CoverageType = coverageType;
        Amount = amount;

    }
}
