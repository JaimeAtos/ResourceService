using Application.Features.ResourcesExtraSkills.UpdateResourceExtraSkillsCommand;
using Microsoft.AspNetCore.Mvc;

namespace ResourceWebApi.Controllers.v1.ResourcesExtraSkills;

[ApiVersion("1.0")]
public class UpdateResourceExtraSkillsController : BaseApiController
{
    [HttpPut]
    public Task<IActionResult> UpdateResourceExtraSkills(UpdateResourceExtraSkillsCommand command, CancellationToken cancellationToken = default)
    {

        if (command is null)
            throw new ArgumentNullException($"The param {command} cannot be null");

        return ProcessUpdateResourceExtraSkills(command);
    }

    private async Task<IActionResult> ProcessUpdateResourceExtraSkills(UpdateResourceExtraSkillsCommand command, CancellationToken cancellationToken = default)
    {
        await Mediator.Send(command, cancellationToken);
        return NoContent();
    }
}