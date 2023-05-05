using Application.Exceptions;
using Application.Extensions;
using Application.Interfaces;
using Atos.Core.Abstractions.Publishers;
using Atos.Core.EventsDTO;
using Domain.Entities;
using MediatR;

namespace Application.Features.ResourcesExtraSkills.Commands.DeleteResourceExtraSkillsCommand;

public class DeleteResourceExtraSkillsCommand : IRequest<Wrappers.Response<Guid>>
{
    public Guid Id { get; set; }
}

public class
    DeleteResourceExtraSkillsCommandHandler : IRequestHandler<DeleteResourceExtraSkillsCommand, Wrappers.Response<Guid>>
{
    private readonly IRepositoryAsync<ResourceExtraSkills> _repositoryAsync;
    private readonly IPublisherCommands<ResourceExtraSkillDeleted> _publisherCommands;

    public DeleteResourceExtraSkillsCommandHandler(IRepositoryAsync<ResourceExtraSkills> repositoryAsync,
        IPublisherCommands<ResourceExtraSkillDeleted> publisherCommands)
    {
        _repositoryAsync = repositoryAsync;
        _publisherCommands = publisherCommands;
    }

    public Task<Wrappers.Response<Guid>> Handle(DeleteResourceExtraSkillsCommand request,
        CancellationToken cancellationToken)
    {
        if (request is null)
            throw new KeyNotFoundException();

        return ProcessHandle(request, cancellationToken);
    }

    public async Task<Wrappers.Response<Guid>> ProcessHandle(DeleteResourceExtraSkillsCommand request,
        CancellationToken cancellationToken)
    {
        var resourceExtraSkills = await _repositoryAsync.GetByIdAsync(request.Id);
        if (resourceExtraSkills is null)
            throw new ApiException($"Record with id {request.Id} not founded");

        resourceExtraSkills.State = false;

        await _repositoryAsync.UpdateAsync(resourceExtraSkills, cancellationToken);

        await _publisherCommands.PublishEntityMessage(request.ToResourceExtraSkillDeleted(),
            "resourceExtraSkill.deleted", request.Id, cancellationToken);

        return new Wrappers.Response<Guid>(resourceExtraSkills.Id);
    }
}