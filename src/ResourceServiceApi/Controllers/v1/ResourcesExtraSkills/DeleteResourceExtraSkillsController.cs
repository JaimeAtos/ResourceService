using Application.Features.ResourcesExtraSkills.DeleteResourceExtraSkillsCommand;
using Microsoft.AspNetCore.Mvc;

namespace ResourceWebApi.Controllers.v1.ResourcesExtraSkills;

[ApiVersion("1.0")]
public class DeleteResourceExtraSkillsController : BaseApiController
{
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteResourceExtraSkills(Guid id)
    {
        return await ProcessDeleteResourceExtraSkills(id);
    }

    private async Task<IActionResult> ProcessDeleteResourceExtraSkills(Guid id)
    {
        var result = await Mediator.Send(new DeleteResourceExtraSkillsCommand { Id = id });
        return Ok(result);
    }
}