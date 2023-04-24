using Application.Features.Resources.Commands.UpdateResourceCommand;
using Microsoft.AspNetCore.Mvc;

namespace ResourceWebApi.Controllers.v1.Resources;


[ApiVersion("1.0")]
public class UpdateResourceController : BaseApiController
{
    /// <summary>
    /// Endpoint to update a resource using all them attributes
    /// </summary>
    /// <param name="id">Guid of the resource</param>
    /// <param name="command">Json to send the request to update the resource using the Guid</param>
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