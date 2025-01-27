using Insurance.Application.Models;
using Insurance.Domain.Entities;
using MediatR;

namespace Insurance.Application.Commands;

public record CreateRequestCommand : IRequest<int>
{
    public string Title { get; set; } = null!;
    public IEnumerable<CoverageModel> Coverages { get; set; } = null!;
}