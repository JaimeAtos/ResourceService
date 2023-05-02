using Application.DTOs;
using Application.Interfaces;
using Application.Specification;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ResourcesExtraSkills.Queries.GetAllResourcesExtraSkills;

public class GetAllResourcesExtraSkillsQuery : IRequest<PagedResponse<List<ResourceExtraSkillsDto>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string? Title { get; set; }
    public string? ExperienceOverallTypeTag { get; set; }
    public string? BriefDescription { get; set; }
    public bool? IsApproved { get; set; }
    public bool State { get; set; }
}

public class GetAllResourcesExtraSkillsHandler : IRequestHandler<GetAllResourcesExtraSkillsQuery, PagedResponse<List<ResourceExtraSkillsDto>>>
{
    private readonly IRepositoryAsync<ResourceExtraSkills> _repositoryAsync;
    private readonly IMapper _mapper;

    public GetAllResourcesExtraSkillsHandler(IRepositoryAsync<ResourceExtraSkills> repositoryAsync, IMapper mapper)
    {
        _repositoryAsync=repositoryAsync;
        _mapper=mapper;
    }
    public async Task<PagedResponse<List<ResourceExtraSkillsDto>>> Handle(GetAllResourcesExtraSkillsQuery request, CancellationToken cancellationToken)
    {
        var pagination = new PagedResourcesExtraSkillsSpecification(request.PageSize, request.PageNumber, request.Title, 
            request.ExperienceOverallTypeTag, request.BriefDescription, request.IsApproved, request.State);

        var resourcesExtraSkills = await _repositoryAsync.ListAsync(pagination);

        var resourcesExtraSkillsDto = _mapper.Map<List<ResourceExtraSkillsDto>>(resourcesExtraSkills);

        return new PagedResponse<List<ResourceExtraSkillsDto>>(resourcesExtraSkillsDto, request.PageNumber, request.PageSize);
    }
}
