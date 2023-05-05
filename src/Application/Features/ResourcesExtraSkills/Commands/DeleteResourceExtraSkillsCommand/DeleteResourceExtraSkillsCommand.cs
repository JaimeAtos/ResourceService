using Application.Exceptions;
using Application.Extensions;
using Application.Interfaces;
using Atos.Core.EventsDTO;
using Domain.Entities;
using MassTransit;
using MediatR;

namespace Application.Features.ResourcesExtraSkills.DeleteResourceExtraSkillsCommand;

public class DeleteResourceExtraSkillsCommand : IRequest<Wrappers.Response<Guid>>
{
    public Guid Id { get; set; }
}

public class DeleteResourceExtraSkillsCommandHandler : IRequestHandler<DeleteResourceExtraSkillsCommand, Wrappers.Response<Guid>>
{
    private readonly IRepositoryAsync<ResourceExtraSkills> _repositoryAsync;
    private readonly IPublishEndpoint _publishEndpoint;

    public DeleteResourceExtraSkillsCommandHandler(IRepositoryAsync<ResourceExtraSkills> repositoryAsync, IPublishEndpoint publishEndpoint)
    {
        _repositoryAsync = repositoryAsync;
        _publishEndpoint = publishEndpoint;

    }

    public Task<Wrappers.Response<Guid>> Handle(DeleteResourceExtraSkillsCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new KeyNotFoundException();

        return ProcessHandle(request, cancellationToken);

    }

    public async Task<Wrappers.Response<Guid>> ProcessHandle(DeleteResourceExtraSkillsCommand request, CancellationToken cancellationToken)
    {
        var resourceExtraSkills = await _repositoryAsync.GetByIdAsync(request.Id);
        if (resourceExtraSkills is null)
            throw new ApiException($"Record with id {request.Id} not founded");

        resourceExtraSkills.State = false;

        await _repositoryAsync.UpdateAsync(resourceExtraSkills, cancellationToken);

        await PublishResourceExtraSkillDeleted(request.ToResourceExtraSkillDeleted(), cancellationToken);

        return new Wrappers.Response<Guid>(resourceExtraSkills.Id);
    }
    
    private async Task PublishResourceExtraSkillDeleted(ResourceExtraSkillDeleted request, CancellationToken cancellationToken)
    {
        await _publishEndpoint.Publish(
            request,
            ctx =>
            {
                ctx.MessageId = request.Id;
                ctx.SetRoutingKey("resourceExtraSkill.deleted");
            },
            cancellationToken);
    }
}

