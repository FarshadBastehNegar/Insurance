using Insurance.Domain.Enums;

namespace Insurance.Application.Models;

public class CoverageModel
{
    public CoverageEnum CoverageType { get; set; }
    public decimal Amount { get; set; }
}
