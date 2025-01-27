using CleanArchitecture.Domain.Common;
using Insurance.Domain.Services;

namespace Insurance.Domain.Entities;

public class Request : BaseAuditableEntity<int>
{
    public string Title { get; private set; }
    public List<Coverage> Coverages { get; private set; } = new List<Coverage>();
    public decimal TotalPremium { get; private set; }

    private Request()
    {

    }

    public static Request Create(string title, List<Coverage> coverages)
    {
        var request = new Request
        {
            Title = title,
            Coverages = coverages,
            Created = DateTime.Now
        };
        request.CalculateTotalPremium();

        return request;
    }

    private void CalculateTotalPremium()
    {
        TotalPremium = Coverages.Sum(c => CoveragePremiumCalculator.Calculate(c));
    }
}