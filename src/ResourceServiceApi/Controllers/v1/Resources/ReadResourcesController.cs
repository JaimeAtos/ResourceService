using Application.Features.Resources.Queries.GetAllResources;
using Application.Features.Resources.Queries.GetReourceById;
using Microsoft.AspNetCore.Mvc;

namespace ResourceWebApi.Controllers.v1.Resources
{

    [ApiVersion("1.0")]
    public class ReadResourcesController : BaseApiController
    {
        /// <summary>
        /// Endpoint to read a specific resource using them Id
        /// </summary>
        /// <param name="id">Guid of the resource</param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetResourceById")]
        public async Task<IActionResult> GetResourceById(Guid id)
        {
            return Ok(await Mediator.Send(new GetResourceByIdQuery { Id = id}));
        }

        /// <summary>
        /// Endpoint to obtain certain resource by use of 
        /// some filters, we obtain all the resources if
        /// all the filters are empty
        /// </summary>
        /// <returns>All the resources that match with the filter selection</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllResources([FromQuery]GetAllResourceParameters filters)
        {
            return Ok(await Mediator.Send(new GetAllResourcesQuery 
            {
                ResourceName = filters.ResourceName,
                PageNumber = filters.PageNumber, 
                PageSize = filters.PageSize,
                WorkEmail = filters.WorkEmail,
                Phone = filters.Phone,
                CurrentStateDescription = filters.CurrentStateDescription,
                CurrentPositionDescription = filters.CurrentPositionDescription,
                NessieID = filters.NessieID,
                CurrentClientName = filters.CurrentClientName,
                Gcm = filters.Gcm,
                IsNational = filters.IsNational,
                State = filters.State
            }));
        }
    }
}
