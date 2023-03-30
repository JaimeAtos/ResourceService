using Application.Features.ResourcesSkills.Commands.CreateResourceSkillCommand;
using Microsoft.AspNetCore.Mvc;

namespace ResourceWebApi.Controllers.v1.ResourcesSkills
{
    [ApiVersion("1.0")]
    public class CreateResourceSkillsController : BaseApiController
    {
        [HttpPost]
        public Task<IActionResult> CreateResourceSkills(CreateResourceSkillsCommand command)
        {
            if (command is null)
                throw new ArgumentNullException($"The param {command} cannot be null");

            return ProcessCreateResourceSkills(command);
        }

        private async Task<IActionResult> ProcessCreateResourceSkills(CreateResourceSkillsCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
