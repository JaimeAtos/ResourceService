using Application.DTOs;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ResourcesExtraSkills.Queries.GetResourceExtraSkillById;

public class GetResourceExtraSkillsByIdQuery : IRequest<Response<ResourceExtraSkillsDto>>
{
    public Guid Id { get; set; }
}

public class GetResourceExtraSkillsByIdQueryHandler : IRequestHandler<GetResourceExtraSkillsByIdQuery, Response<ResourceExtraSkillsDto>>
{
    private readonly IRepositoryAsync<ResourceExtraSkills> _repositoryAsync;
    private readonly IMapper _mapper;

    public GetResourceExtraSkillsByIdQueryHandler(IMapper mapper, IRepositoryAsync<ResourceExtraSkills> repositoryAsync)
    {
        _mapper=mapper;
        _repositoryAsync=repositoryAsync;
    }

    public Task<Response<ResourceExtraSkillsDto>> Handle(GetResourceExtraSkillsByIdQuery request, CancellationToken cancellationToken)
    {

        if (request == null)
            throw new ArgumentNullException();
        return ProcessHandle(request, cancellationToken);
    }

    public async Task<Response<ResourceExtraSkillsDto>> ProcessHandle(GetResourceExtraSkillsByIdQuery request, CancellationToken cancellationToken)
    {
        var resourceExtraSkills = await _repositoryAsync.GetByIdAsync(request.Id);
        if (resourceExtraSkills == null)
            throw new KeyNotFoundException($"Record with id {request.Id} not found");
        else
        {
            var dto = _mapper.Map<ResourceExtraSkillsDto>(resourceExtraSkills);
            return new Response<ResourceExtraSkillsDto>(dto);
        }
    }
}
