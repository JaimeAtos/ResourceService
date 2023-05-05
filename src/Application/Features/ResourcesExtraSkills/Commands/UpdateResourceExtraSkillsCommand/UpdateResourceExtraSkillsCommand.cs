using Application.Exceptions;
using Application.Extensions;
using Application.Interfaces;
using Atos.Core.EventsDTO;
using Domain.Entities;
using MassTransit;
using MediatR;

namespace Application.Features.ResourcesExtraSkills.UpdateResourceExtraSkillsCommand;

public class UpdateResourceExtraSkillsCommand : IRequest<Wrappers.Response<Guid>>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public Guid ResourceId { get; set; }
    public string ExperienceOverallTypeTag { get; set; } //Certification, Course,
    public string BriefDescription { get; set; }
    public byte Point { get; set; }
    public bool IsApproved { get; set; }
}

public class UpdateResourceExtraSkillsCommandHandler : IRequestHandler<UpdateResourceExtraSkillsCommand, Wrappers.Response<Guid>>
{
    private readonly IRepositoryAsync<ResourceExtraSkills> _repositoryAsync;
    private readonly IPublishEndpoint _publishEndpoint;

    public UpdateResourceExtraSkillsCommandHandler(IRepositoryAsync<ResourceExtraSkills> repositoryAsync, IPublishEndpoint publishEndpoint)
    {
        _repositoryAsync=repositoryAsync;
        _publishEndpoint=publishEndpoint;
    }

    public Task<Wrappers.Response<Guid>> Handle(UpdateResourceExtraSkillsCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new KeyNotFoundException();

        return ProcessHandle(request, cancellationToken);

    }

    public async Task<Wrappers.Response<Guid>> ProcessHandle(UpdateResourceExtraSkillsCommand request, CancellationToken cancellationToken)
    {
        var resourceExtraSkills = await _repositoryAsync.GetByIdAsync(request.Id);
        if (resourceExtraSkills is null)
            throw new ApiException($"Record with id {request.Id} not founded");

        resourceExtraSkills.Title = request.Title;
        resourceExtraSkills.ResourceId = request.ResourceId;
        resourceExtraSkills.ExperienceOverallTypeTag = request.ExperienceOverallTypeTag;
        resourceExtraSkills.BriefDescription = request.BriefDescription;
        resourceExtraSkills.Point = request.Point;
        resourceExtraSkills.IsApproved = request.IsApproved;

        await _repositoryAsync.UpdateAsync(resourceExtraSkills);

        await PublishUpdateResourceExtraSkillCommand(request.ToResourceExtraSkillUpdated(), cancellationToken);

        return new Wrappers.Response<Guid>(resourceExtraSkills.Id);
    }
    
    private async Task PublishUpdateResourceExtraSkillCommand(ResourceExtraSkillUpdated request, CancellationToken cancellationToken)
    {
        await _publishEndpoint.Publish(
            request,
            ctx =>
            {
                ctx.MessageId = request.Id;
                ctx.SetRoutingKey("resourceExtraSkill.updated");
            },
            cancellationToken);
    }
}