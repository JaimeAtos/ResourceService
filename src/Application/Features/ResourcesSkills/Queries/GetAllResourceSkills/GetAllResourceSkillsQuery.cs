using Application.DTOs;
using Application.Features.ResourcesExtraSkills.Queries.GetAllResourcesExtraSkills;
using Application.Interfaces;
using Application.Specification;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ResourcesSkills.Queries.GetAllResourceSkills;

public class GetAllResourceSkillsQuery : IRequest<PagedResponse<List<ResourceSkillsDto>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string? SkillName { get; set; }
    public string? SkillAcceptanceURL { get; set; }
    public bool? IsCompliance { get; set; }
    public bool State { get; set; }
}

public class GetAllResourceSkillsQueryHandler : IRequestHandler<GetAllResourceSkillsQuery, PagedResponse<List<ResourceSkillsDto>>>
{
    private readonly IRepositoryAsync<ResourceSkills> _repositoryAsync;
    private readonly IMapper _mapper;

    public GetAllResourceSkillsQueryHandler(IRepositoryAsync<ResourceSkills> repositoryAsync, IMapper mapper)
    {
        _repositoryAsync=repositoryAsync;
        _mapper=mapper;
    }

    public async Task<PagedResponse<List<ResourceSkillsDto>>> Handle(GetAllResourceSkillsQuery request, CancellationToken cancellationToken)
    {
        var pagination = new PagedResourcesSkillsSpecification(request.PageSize, request.PageNumber, request.SkillName,
            request.SkillAcceptanceURL, request.IsCompliance, request.State);

        var resourcesSkills = await _repositoryAsync.ListAsync(pagination);

        var resourcesSkillsDto = _mapper.Map<List<ResourceSkillsDto>>(resourcesSkills);

        return new PagedResponse<List<ResourceSkillsDto>>(resourcesSkillsDto, request.PageNumber, request.PageSize);
    }
}

