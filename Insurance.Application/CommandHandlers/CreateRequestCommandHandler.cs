using Insurance.Application.Commands;
using Insurance.Application.Contracts;
using Insurance.Application.Models.Options;
using Insurance.Domain.Entities;
using Insurance.Domain.Enums;
using MediatR;
using Microsoft.Extensions.Options;

namespace Insurance.Application.CommandHandlers;
public class CreateRequestCommandHandler : IRequestHandler<CreateRequestCommand, int>
{
    private readonly IInsuranceDbContext _context;
    private readonly InsuranceSetting _insuranceSetting;

    public CreateRequestCommandHandler(IInsuranceDbContext context,
        IOptions<InsuranceSetting> insuranceSetting)
    {
        _context = context;
        _insuranceSetting = insuranceSetting.Value;
    }

    public async Task<int> Handle(CreateRequestCommand request, CancellationToken ct)
    {
        foreach (var item in request.Coverages)
        {
            switch (item.CoverageType)
            {
                case CoverageEnum.Surgery:
                    {
                        if (item.Amount < _insuranceSetting.Coverage.Surgery.MinAmount ||
                            item.Amount > _insuranceSetting.Coverage.Surgery.MaxAmount)
                            throw new ArgumentOutOfRangeException();

                        break;
                    }
                case CoverageEnum.Dentistry:
                    {
                        if (item.Amount < _insuranceSetting.Coverage.Dentistry.MinAmount ||
                            item.Amount > _insuranceSetting.Coverage.Dentistry.MaxAmount)
                            throw new ArgumentOutOfRangeException();

                        break;
                    }
                case CoverageEnum.Confinement:
                    {
                        if (item.Amount < _insuranceSetting.Coverage.Confinement.MinAmount ||
                            item.Amount > _insuranceSetting.Coverage.Confinement.MaxAmount)
                            throw new ArgumentOutOfRangeException();

                        break;
                    }
                default:
                    throw new Exception();
            }
        }

        var Coverages = request.Coverages
            .Select(cm => new Domain.Entities.Coverage(cm.CoverageType, cm.Amount))
            .ToList();
        var entity = Request.Create(request.Title, Coverages);
        _context.Requests.Add(entity);
        await _context.SaveChangesAsync(ct);

        return entity.Id;
    }
}
