using Application.Features.Resources.Commands.UpdateResourceCommand;
using Microsoft.AspNetCore.Mvc;

namespace ResourceWebApi.Controllers.v1.Resources;


[ApiVersion("1.0")]
public class UpdateResourceController : BaseApiController
{
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateResource(Guid id, UpdateResourceCommand command)
    {

        if (id != command.Id)
            return BadRequest();

        return await ProcessUpdateResource(command);
    }

    private async Task<IActionResult> ProcessUpdateResource(UpdateResourceCommand command)
    {
        var result = await Mediator.Send(command);
        return Ok(result);
    }
}