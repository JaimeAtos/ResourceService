using Application.Exceptions;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ResourcesExtraSkills.UpdateResourceExtraSkillsCommand;

public class UpdateResourceExtraSkillsCommand : IRequest<Response<Guid>>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public Guid ResourceId { get; set; }
    public string ExperienceOveralTypeTag { get; set; } //Certification, Course,
    public string BriefDescription { get; set; }
    public byte Point { get; set; }
    public bool IsApproved { get; set; }
}

public class UpdateResourceExtraSkillsCommandHandler : IRequestHandler<UpdateResourceExtraSkillsCommand, Response<Guid>>
{
    private readonly IRepositoryAsync<ResourceExtraSkills> _repositoryAsync;
    private readonly IMapper _mapper;

    public UpdateResourceExtraSkillsCommandHandler(IRepositoryAsync<ResourceExtraSkills> repositoryAsync, IMapper mapper)
    {
        _repositoryAsync=repositoryAsync;
        _mapper=mapper;
    }

    public Task<Response<Guid>> Handle(UpdateResourceExtraSkillsCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new KeyNotFoundException();

        return ProcessHandle(request, cancellationToken);

    }

    public async Task<Response<Guid>> ProcessHandle(UpdateResourceExtraSkillsCommand request, CancellationToken cancellationToken)
    {
        var resourceExtraSkills = await _repositoryAsync.GetByIdAsync(request.Id);
        if (resourceExtraSkills is null)
            throw new ApiException($"Record with id {request.Id} not founded");

        resourceExtraSkills.Title = request.Title;
        resourceExtraSkills.ResourceId = request.ResourceId;
        resourceExtraSkills.ExperienceOveralTypeTag = request.ExperienceOveralTypeTag;
        resourceExtraSkills.BriefDescription = request.BriefDescription;
        resourceExtraSkills.Point = request.Point;
        resourceExtraSkills.IsApproved = request.IsApproved;

        await _repositoryAsync.UpdateAsync(resourceExtraSkills);

        return new Response<Guid>(resourceExtraSkills.Id);
    }
}