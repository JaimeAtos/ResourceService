using Application.Features.Resources.Commands.CreateResourceCommand;
using Microsoft.AspNetCore.Mvc;

namespace ResourceWebApi.Controllers.v1.Resources;


[ApiVersion("1.0")]
public class CreateResourceController : BaseApiController
{
    /// <summary>
    /// Endpoint to create a human resource
    /// </summary>
    /// <param name="command"></param>
    /// <returns>Guid</returns>
    /// <response code="200">Id of the created resource</response>
    /// <exception cref="ArgumentNullException"></exception>
    [HttpPost]
    public Task<IActionResult> CreateResource(CreateResourceCommand command, CancellationToken cancellationToken = default)
    {
        if (command is null)
            throw new ArgumentNullException($"The param {command} cannot be null");

        return ProcessCreateResource(command, cancellationToken);
    }

    private async Task<IActionResult> ProcessCreateResource(CreateResourceCommand command, CancellationToken cancellationToken = default)
    {
        var result = await Mediator.Send(command, cancellationToken);
        return CreatedAtRoute("GetResourceById", routeValues: new { id = result.Data }, command);
    }
}
