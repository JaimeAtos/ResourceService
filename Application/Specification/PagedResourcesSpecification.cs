using Ardalis.Specification;
using Domain.Entities;

namespace Application.Specification;

public class PagedResourcesSpecification : Specification<Resource>
{
    public PagedResourcesSpecification(int pageSize, int pageNumber, string fullName, string workEmail, string phone, string currentStateDescription, 
        string currentPositionDescription, string nessieId, string currentClientName)
    {
        Query.Skip((pageNumber - 1)* pageSize)
            .Take(pageSize);

        if(!string.IsNullOrEmpty(fullName))
            Query.Search(x => x.FullName, "%" + fullName + "%");

        if (!string.IsNullOrEmpty(workEmail))
            Query.Search(x => x.FullName, "%" + workEmail + "%");

        if (!string.IsNullOrEmpty(phone))
            Query.Search(x => x.FullName, "%" + phone + "%");

        if (!string.IsNullOrEmpty(currentStateDescription))
            Query.Search(x => x.FullName, "%" + currentStateDescription + "%");

        if (!string.IsNullOrEmpty(currentPositionDescription))
            Query.Search(x => x.FullName, "%" + currentPositionDescription + "%");

        if (!string.IsNullOrEmpty(nessieId))
            Query.Search(x => x.FullName, "%" + nessieId + "%");

        if (!string.IsNullOrEmpty(currentClientName))
            Query.Search(x => x.FullName, "%" + currentClientName + "%");
    }
}
