using Insurance.Domain.Entities;

namespace Insurance.Application.Models;

public class GetRequestModel
{
    public int Id { get; set; }
    public DateTimeOffset Created { get; set; }
    public DateTimeOffset? LastModified { get; set; }
    public string Title { get; set; } = null!;
    public List<Coverage> Coverages { get; set; } = null!;
    public decimal TotalPremium { get;  set; }
}
