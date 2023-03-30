using Application.DTOs;
using Application.Features.ResourcesExtraSkills.Queries.GetResourceExtraSkillById;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ResourcesSkills.Queries.GetResourceSkillsById;

public class GetResourceSkillsByIdQuery : IRequest<Response<ResourceSkillsDto>>
{
    public Guid Id { get; set; }
}

public class GetResourceSkillsByIdQueryHandler : IRequestHandler<GetResourceSkillsByIdQuery, Response<ResourceSkillsDto>>
{
    private readonly IRepositoryAsync<ResourceSkills> _repositoryAsync;
    private readonly IMapper _mapper;

    public GetResourceSkillsByIdQueryHandler(IMapper mapper, IRepositoryAsync<ResourceSkills> repositoryAsync)
    {
        _mapper=mapper;
        _repositoryAsync=repositoryAsync;
    }

    public Task<Response<ResourceSkillsDto>> Handle(GetResourceSkillsByIdQuery request, CancellationToken cancellationToken)
    {
        if (request == null)
            throw new ArgumentNullException();
        return ProcessHandle(request, cancellationToken);
    }

    public async Task<Response<ResourceSkillsDto>> ProcessHandle(GetResourceSkillsByIdQuery request, CancellationToken cancellationToken)
    {
        var resourceExtraSkills = await _repositoryAsync.GetByIdAsync(request.Id);
        if (resourceExtraSkills == null)
            throw new KeyNotFoundException($"Record with id {request.Id} not found");
        else
        {
            var dto = _mapper.Map<ResourceSkillsDto>(resourceExtraSkills);
            return new Response<ResourceSkillsDto>(dto);
        }
    }
}