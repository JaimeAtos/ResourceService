using Ardalis.Specification;
using Domain.Entities;

namespace Application.Specification;

public class PagedResourcesSpecification : Specification<Resource>
{
    public PagedResourcesSpecification(int pageSize, int pageNumber, string workEmail, string phone, string currentStateDescription, 
        string currentPositionDescription, string nessieId, string currentClientName, string resourceName, bool isNational)
    {
        Query.Skip((pageNumber - 1)* pageSize)
            .Take(pageSize);
        
        if (!string.IsNullOrEmpty(workEmail))
            Query.Search(x => x.WorkEmail, "%" + workEmail + "%");

        if (!string.IsNullOrEmpty(phone))
            Query.Search(x => x.Phone, "%" + phone + "%");

        if (!string.IsNullOrEmpty(currentStateDescription))
            Query.Search(x => x.CurrentStateDescription, "%" + currentStateDescription + "%");

        if (!string.IsNullOrEmpty(currentPositionDescription))
            Query.Search(x => x.CurrentPositionDescription, "%" + currentPositionDescription + "%");

        if (!string.IsNullOrEmpty(nessieId))
            Query.Search(x => x.NessieID, "%" + nessieId + "%");

        if (!string.IsNullOrEmpty(currentClientName))
            Query.Search(x => x.CurrentClientName, "%" + currentClientName + "%");
        
        if (!string.IsNullOrEmpty(resourceName))
            Query.Search(x => x.ResourceName, "%" + resourceName + "%");

        if (isNational)
            Query.Search(x => x.IsNational.ToString(), "%" + isNational + "%");

    }
}
