﻿using Application.Features.ResourcesSkills.Queries.GetAllResourceSkills;
using Application.Features.ResourcesSkills.Queries.GetResourceSkillsById;
using Microsoft.AspNetCore.Mvc;

namespace ResourceWebApi.Controllers.v1.ResourcesSkills
{
    [ApiVersion("1.0")]
    public class ReadResourceSkillsController : BaseApiController
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetResourceSkillsById(Guid id)
        {
            return Ok(await Mediator.Send(new GetResourceSkillsByIdQuery { Id = id }));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllResourceSkills([FromQuery] GetAllResourceSkillsParameters filters)
        {
            return Ok(await Mediator.Send(new GetAllResourceSkillsQuery
            {
                PageNumber = filters.PageNumber,
                PageSize = filters.PageSize,
                ResourceName = filters.ResourceName,
                SkillName = filters.SkillName,
                SkillAcceptanceURL = filters.SkillAcceptanceURL,
                IsComplice = filters.IsComplice
            }));
        }
    }
}
