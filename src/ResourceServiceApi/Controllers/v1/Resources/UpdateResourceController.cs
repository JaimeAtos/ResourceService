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
    [HttpPut]
    public Task<IActionResult> UpdateResource(UpdateResourceCommand command, CancellationToken cancellationToken = default)
    {

        if (command is null)
            throw new ArgumentNullException($"The param {command} cannot be null");

        return ProcessUpdateResource(command, cancellationToken);
    }

    private async Task<IActionResult> ProcessUpdateResource(UpdateResourceCommand command, CancellationToken cancellationToken = default)
    {
        await Mediator.Send(command, cancellationToken);
        return NoContent();
    }
}