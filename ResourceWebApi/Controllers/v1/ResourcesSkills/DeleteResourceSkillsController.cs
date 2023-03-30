using Application.Features.ResourcesSkills.Commands.DeleteResourceSkillCommand;
using Microsoft.AspNetCore.Mvc;

namespace ResourceWebApi.Controllers.v1.ResourcesSkills
{
    [ApiVersion("1.0")]
    public class DeleteResourceSkillsController : BaseApiController
    {
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResourceSkills(Guid id)
        {
            return await ProcessDeleteResourceSkills(id);
        }

        private async Task<IActionResult> ProcessDeleteResourceSkills(Guid id)
        {
            var result = await Mediator.Send(new DeleteResourceSkillsCommand { Id = id });
            return Ok(result);
        }
    }
}
