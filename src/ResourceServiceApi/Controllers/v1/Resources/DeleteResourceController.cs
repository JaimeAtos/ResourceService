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
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteResource(Guid id)
    {
        return await ProcessDeleteResource(id);
    }

    private async Task<IActionResult> ProcessDeleteResource(Guid id)
    {
        var result = await Mediator.Send(new DeleteResourceCommand { Id = id});
        return Ok(result);
    }
}