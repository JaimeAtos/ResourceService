using Application.Features.Resources.Queries.GetAllResources;
using Ardalis.Specification;
using Domain.Entities;

namespace Application.Specification;

public class PagedResourcesSpecification : Specification<Resource>
{
    public PagedResourcesSpecification(GetAllResourcesQuery request)
    {
        Query.Skip((request.PageNumber) * request.PageSize)
            .Take(request.PageSize);

        if (!string.IsNullOrEmpty(request.ResourceName))
            Query.Search(x => x.ResourceName, "%" + request.ResourceName + "%");

        if (!string.IsNullOrEmpty(request.WorkEmail))
            Query.Search(x => x.WorkEmail, "%" + request.WorkEmail + "%");

        if (!string.IsNullOrEmpty(request.Phone))
            Query.Search(x => x.Phone, "%" + request.Phone + "%");

        if (!string.IsNullOrEmpty(request.CurrentStateDescription))
            Query.Search(x => x.CurrentStateDescription, "%" + request.CurrentStateDescription + "%");

        if (!string.IsNullOrEmpty(request.CurrentPositionDescription))
            Query.Search(x => x.CurrentPositionDescription, "%" + request.CurrentPositionDescription + "%");

        if (!string.IsNullOrEmpty(request.NessieID))
            Query.Search(x => x.NessieID, "%" + request.NessieID + "%");

        if (!string.IsNullOrEmpty(request.CurrentClientName))
            Query.Search(x => x.CurrentClientName, "%" + request.CurrentClientName + "%");
        
        if (!string.IsNullOrEmpty(request.Gcm.ToString()))
            Query.Search(x => x.Gcm.ToString(), "%" + request.Gcm + "%");
        
        if (!string.IsNullOrEmpty(request.IsNational.ToString()))
            Query.Search(x => x.IsNational.ToString(), request.IsNational.ToString());
        
        Query.Search(x => x.State.ToString(), request.State.ToString());
    }
}
