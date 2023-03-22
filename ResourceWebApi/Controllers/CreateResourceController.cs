using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ResourceWebApi.Controllers;
[ApiController]
public class CreateResourceController
{
    private readonly IMediator _mediator;
    public CreateResourceController(IMediator mediator)
    {
        _mediator=mediator;
    }
}
