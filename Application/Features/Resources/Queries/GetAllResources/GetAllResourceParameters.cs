using Application.Parameters;

namespace Application.Features.Resources.Queries.GetAllResources;

public class GetAllResourceParameters : RequestParameter
{
    public string? FullName { get; set; }
    public string? WorkEmail { get; set; }
    public string? Phone { get; set; }
    public string? CurrentStateDescription { get; set; }
    public string? CurrentPositionDescription { get; set; }
    public string? NessieID { get; set; }
    public string? CurrentClientName { get; set; }


}
