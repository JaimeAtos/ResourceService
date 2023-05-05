using Application.Exceptions;
using Application.Extensions;
using Application.Interfaces;
using Atos.Core.Abstractions.Publishers;
using Atos.Core.EventsDTO;
using Domain.Entities;
using MassTransit;
using MediatR;

namespace Application.Features.Resources.Commands.DeleteResourceCommand;

public class DeleteResourceCommand : IRequest<Wrappers.Response<Guid>>
{
    public Guid Id { get; set; }
}

public class DeleteResourceCommandHandler : IRequestHandler<DeleteResourceCommand, Wrappers.Response<Guid>>
{
    private readonly IRepositoryAsync<Resource> _repositoryAsync;
    private readonly IPublisherCommands<ResourceDeleted> _publisherCommands;

    public DeleteResourceCommandHandler(IRepositoryAsync<Resource> repositoryAsync,
        IPublisherCommands<ResourceDeleted> publisherCommands)
    {
        _repositoryAsync = repositoryAsync;
        _publisherCommands = publisherCommands;
    }

    public Task<Wrappers.Response<Guid>> Handle(DeleteResourceCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new KeyNotFoundException();

        return ProcessHandle(request, cancellationToken);
    }

    public async Task<Wrappers.Response<Guid>> ProcessHandle(DeleteResourceCommand request,
        CancellationToken cancellationToken)
    {
        var resource = await _repositoryAsync.GetByIdAsync(request.Id, cancellationToken);
        if (resource is null)
            throw new ApiException($"Record with id {request.Id} not found");

        resource.State = false;

        await _repositoryAsync.UpdateAsync(resource);

        await _publisherCommands.PublishEntityMessage(request.ToResourceDeleted(), "resource.deleted", request.Id,
            cancellationToken);

        return new Wrappers.Response<Guid>(resource.Id);
    }
}