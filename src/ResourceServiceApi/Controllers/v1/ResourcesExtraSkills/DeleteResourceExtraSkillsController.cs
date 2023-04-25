using Application.Features.ResourcesExtraSkills.DeleteResourceExtraSkillsCommand;
using Microsoft.AspNetCore.Mvc;

namespace ResourceWebApi.Controllers.v1.ResourcesExtraSkills;

[ApiVersion("1.0")]
public class DeleteResourceExtraSkillsController : BaseApiController
{
    [HttpDelete]
    public Task<IActionResult> DeleteResourceExtraSkills(DeleteResourceExtraSkillsCommand command, CancellationToken cancellationToken = default)
    {
        if (command is null)
            throw new ArgumentNullException();

        return ProcessDeleteResourceExtraSkills(command, cancellationToken);
    }

    private async Task<IActionResult> ProcessDeleteResourceExtraSkills(DeleteResourceExtraSkillsCommand command, CancellationToken cancellationToken = default)
    {
        await Mediator.Send(command, cancellationToken);
        return NoContent();
    }
}