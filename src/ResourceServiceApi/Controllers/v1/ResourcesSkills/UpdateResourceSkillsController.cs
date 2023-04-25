using Application.Features.ResourcesSkills.Commands.UpdateResourceSkillCommand;
using Microsoft.AspNetCore.Mvc;

namespace ResourceWebApi.Controllers.v1.ResourcesSkills
{
    [ApiVersion("1.0")]
    public class UpdateResourceSkillsController : BaseApiController
    {
        [HttpPut]
        public Task<IActionResult> UpdateResourceSkills(UpdateResourceSkillsCommand command, CancellationToken cancellationToken = default)
        {

            if (command is null)
                throw new ArgumentNullException($"The param {command} cannot be null");

            return ProcessUpdateResourceSkills(command, cancellationToken);
        }

        private async Task<IActionResult> ProcessUpdateResourceSkills(UpdateResourceSkillsCommand command, CancellationToken cancellationToken = default)
        {
            await Mediator.Send(command, cancellationToken);
            return NoContent();
        }
    }
}
