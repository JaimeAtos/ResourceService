using Application.Features.Resources.Commands.DeleteResourceCommand;
using Microsoft.AspNetCore.Mvc;

namespace ResourceWebApi.Controllers.v1.Resources;

[ApiVersion("1.0")]
public class DeleteResourceController : BaseApiController
{
    /// <summary>
    /// Endpoint to logical delete a human resource
    /// </summary>
    /// <param name="id">Guid of the wantedd to delete resource</param>
    /// <response code="200">Id of the deleted resource</response>
    /// <exception cref="ArgumentNullException"></exception>
    [HttpDelete]
    public Task<IActionResult> DeleteResource(DeleteResourceCommand command, CancellationToken cancellationToken = default)
    {
        if (command is null)
            throw new ArgumentNullException();

        return ProcessDeleteResource(command, cancellationToken);
    }

    private async Task<IActionResult> ProcessDeleteResource(DeleteResourceCommand command, CancellationToken cancellationToken = default)
    {
        await Mediator.Send(command, cancellationToken);
        return NoContent();
    }
}