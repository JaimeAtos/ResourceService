using Application.Features.ResourcesSkills.Commands.DeleteResourceSkillCommand;
using Microsoft.AspNetCore.Mvc;

namespace ResourceWebApi.Controllers.v1.ResourcesSkills
{
    [ApiVersion("1.0")]
    public class DeleteResourceSkillsController : BaseApiController
    {
        [HttpDelete]
        public Task<IActionResult> DeleteResourceSkills(DeleteResourceSkillsCommand command, CancellationToken cancellationToken = default)
        {
            if (command is null)
                throw new ArgumentNullException();

            return ProcessDeleteResourceSkills(command, cancellationToken);
        }

        private async Task<IActionResult> ProcessDeleteResourceSkills(DeleteResourceSkillsCommand command, CancellationToken cancellationToken = default)
        {
            await Mediator.Send(command, cancellationToken);
            return NoContent();
        }
    }
}
