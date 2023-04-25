using Application.Features.ResourcesExtraSkills.CreateResourceExtraSkillsCommand;
using Microsoft.AspNetCore.Mvc;

namespace ResourceWebApi.Controllers.v1.ResourcesExtraSkills;

[ApiVersion("1.0")]
public class CreateResourceExtraSkillsController : BaseApiController
{
    [HttpPost]
    public Task<IActionResult> CreateResourceExtraSkills(CreateResourceExtraSkillsCommand command, CancellationToken cancellationToken = default)
    {
        if (command is null)
            throw new ArgumentNullException($"The param {command} cannot be null");

        return ProcessCreateResourceExtraSkills(command, cancellationToken);
    }

    private async Task<IActionResult> ProcessCreateResourceExtraSkills(CreateResourceExtraSkillsCommand command, CancellationToken cancellationToken = default)
    {
        var result = await Mediator.Send(command, cancellationToken);
        return CreatedAtRoute("GetResourceExtraSkillsById", routeValues: new {id = result.Data}, command);
    }
}
