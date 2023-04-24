using Application.Features.ResourcesExtraSkills.UpdateResourceExtraSkillsCommand;
using Microsoft.AspNetCore.Mvc;

namespace ResourceWebApi.Controllers.v1.ResourcesExtraSkills;

[ApiVersion("1.0")]
public class UpdateResourceExtraSkillsController : BaseApiController
{
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateResourceExtraSkills(Guid id, UpdateResourceExtraSkillsCommand command)
    {

        if (id != command.Id)
            return BadRequest();

        return await ProcessUpdateResourceExtraSkills(command);
    }

    private async Task<IActionResult> ProcessUpdateResourceExtraSkills(UpdateResourceExtraSkillsCommand command)
    {
        var result = await Mediator.Send(command);
        return Ok(result);
    }
}