using Application.Features.ResourcesExtraSkills.CreateResourceExtraSkillsCommand;
using Microsoft.AspNetCore.Mvc;

namespace ResourceWebApi.Controllers.v1.ResourcesExtraSkills;

[ApiVersion("1.0")]
public class CreateResourceExtraSkillsController : BaseApiController
{
    [HttpPost]
    public Task<IActionResult> CreateResourceExtraSkills(CreateResourceExtraSkillsCommand command)
    {
        if (command is null)
            throw new ArgumentNullException($"The param {command} cannot be null");

        return ProcessCreateResourceExtraSkills(command);
    }

    private async Task<IActionResult> ProcessCreateResourceExtraSkills(CreateResourceExtraSkillsCommand command)
    {
        var result = await Mediator.Send(command);
        return Ok(result);
    }
}
