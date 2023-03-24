using Application.Features.Resources.Commands.DeleteResourceCommand;
using Microsoft.AspNetCore.Mvc;

namespace ResourceWebApi.Controllers.v1.Resources;


[ApiVersion("1.0")]
public class DeleteResourceController : BaseApiController
{
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