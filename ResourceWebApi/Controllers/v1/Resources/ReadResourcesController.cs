using Application.Features.Resources.Queries.GetAllResources;
using Application.Features.Resources.Queries.GetReourceById;
using Microsoft.AspNetCore.Mvc;

namespace ResourceWebApi.Controllers.v1.Resources
{

    [ApiVersion("1.0")]
    public class ReadResourcesController : BaseApiController
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetResourceById(Guid id)
        {
            return Ok(await Mediator.Send(new GetResourceByIdQuery { Id = id}));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllResources([FromQuery]GetAllResourceParameters filters)
        {
            return Ok(await Mediator.Send(new GetAllResourcesQuery 
            {
                PageNumber = filters.PageNumber, 
                PageSize = filters.PageSize,
                FullName = filters.FullName,
                WorkEmail = filters.WorkEmail,
                Phone = filters.Phone,
                CurrentStateDescription = filters.CurrentStateDescription,
                CurrentPositionDescription = filters.CurrentPositionDescription,
                NessieID = filters.NessieID,
                CurrentClientName = filters.CurrentClientName
            }));
        }
    }
}
