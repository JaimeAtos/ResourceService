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
    public Task<IActionResult> CreateResource(CreateResourceCommand command)
    {
        if (command is null)
            throw new ArgumentNullException($"The param {command} cannot be null");

        return ProcessCreateResource(command);
    }

    private async Task<IActionResult> ProcessCreateResource(CreateResourceCommand command)
    {
        var result = await Mediator.Send(command);
        return CreatedAtRoute("GetResourceById", routeValues: new { id = result }, command);
    }
}
