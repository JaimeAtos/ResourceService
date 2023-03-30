using Application.Features.ResourcesSkills.Commands.UpdateResourceSkillCommand;
using Microsoft.AspNetCore.Mvc;

namespace ResourceWebApi.Controllers.v1.ResourcesSkills
{
    [ApiVersion("1.0")]
    public class UpdateResourceSkillsController : BaseApiController
    {
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateResourceSkills(Guid id, UpdateResourceSkillsCommand command)
        {

            if (id != command.Id)
                return BadRequest();

            return await ProcessUpdateResourceSkills(command);
        }

        private async Task<IActionResult> ProcessUpdateResourceSkills(UpdateResourceSkillsCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
