using Insurance.Application.Commands;
using Insurance.Application.Contracts;
using Insurance.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Insurance.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InsuranceRequestController(IMediator mediator,
    IRequestQuery insuranceRequestQuery) : ControllerBase
{
    private readonly IMediator _mediator = mediator;
    private readonly IRequestQuery _insuranceRequestQuery = insuranceRequestQuery;

    [HttpGet("getall")]
    [ProducesResponseType(typeof(IEnumerable<GetRequestModel>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAll([FromQuery] PaginationModel paging, CancellationToken ct)
        => Ok(await _insuranceRequestQuery.GetAll(paging, ct));


    [HttpPost("create")]
    [ProducesResponseType(typeof(IEnumerable<CreateRequestCommand>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Create([FromBody] CreateRequestCommand model, CancellationToken ct)
        => Ok(await _mediator.Send(model, ct));
}
