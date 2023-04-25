using Application.Features.ResourcesExtraSkills.Queries.GetAllResourcesExtraSkills;
using Application.Features.ResourcesExtraSkills.Queries.GetResourceExtraSkillById;
using Microsoft.AspNetCore.Mvc;

namespace ResourceWebApi.Controllers.v1.ResourcesExtraSkills
{
    [ApiVersion("1.0")]
    public class ReadResourceExtraSkillsController : BaseApiController
    {
        [HttpGet("{id}", Name = "GetResourceExtraSkillsById")]
        public async Task<IActionResult> GetResourceExtraSkillsById(Guid id)
        {
            return Ok(await Mediator.Send(new GetResourceExtraSkillsByIdQuery { Id = id }));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllResourceExtraSkills([FromQuery] GetAllResourcesExtraSkillsParameters filters)
        {
            return Ok(await Mediator.Send(new GetAllResourcesExtraSkillsQuery
            {
                PageNumber = filters.PageNumber,
                PageSize = filters.PageSize,
                Title = filters.Title,
                ExperienceOverallTypeTag = filters.ExperienceOverallTypeTag,
                BriefDescription = filters.BriefDescription,
                IsApproved = filters.IsApproved
            }));
        }
    }
}
