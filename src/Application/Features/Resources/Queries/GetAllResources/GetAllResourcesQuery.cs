using Application.DTOs;
using Application.Interfaces;
using Application.Specification;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Resources.Queries.GetAllResources;

public class GetAllResourcesQuery : IRequest<PagedResponse<List<ResourceDto>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public Guid Id { get; set; }
    public string ResourceName { get; set; }
    public string WorkEmail { get; set; }
    public string Phone { get; set; }
    public string CurrentStateDescription { get; set; }
    public string CurrentPositionDescription { get; set; }
    public string NessieID { get; set; }
    public string CurrentClientName { get; set; }
    public byte? Gcm {get ; set;}
    public bool? IsNational { get; set; }
    public bool State { get; set; }
}
public class GetAllResourcesQueryHandler : IRequestHandler<GetAllResourcesQuery, PagedResponse<List<ResourceDto>>>
{
    private readonly IRepositoryAsync<Resource> _repositoryAsync;
    private readonly IMapper _mapper;


    public GetAllResourcesQueryHandler(IRepositoryAsync<Resource> repositoryAsync, IMapper mapper)
    {
        _repositoryAsync=repositoryAsync;
        _mapper=mapper;
    }

    public async Task<PagedResponse<List<ResourceDto>>> Handle(GetAllResourcesQuery request, CancellationToken cancellationToken)
    {
        var pagination = new PagedResourcesSpecification(request);

        var resource = await _repositoryAsync.ListAsync(pagination);
        var resourceDto = _mapper.Map<List<ResourceDto>>(resource);

        return new PagedResponse<List<ResourceDto>>(resourceDto, request.PageNumber, request.PageSize);
    }
}