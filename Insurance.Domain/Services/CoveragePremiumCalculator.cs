using Insurance.Domain.Entities;
using Insurance.Domain.Enums;

namespace Insurance.Domain.Services;

public static class CoveragePremiumCalculator
{
    public static decimal Calculate(Coverage coverage)
    {
        decimal premiumRate = coverage.CoverageType switch
        {
            CoverageEnum.Surgery => 0.0052m,
            CoverageEnum.Dentistry => 0.0042m,
            CoverageEnum.Confinement => 0.005m,
            _ => throw new ArgumentException("نوع پوشش نامعتبر است.")
        };

        return premiumRate * coverage.Amount; 
    }
}