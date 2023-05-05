using Application.Exceptions;
using Application.Extensions;
using Application.Interfaces;
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
    private readonly IPublishEndpoint _publishEndpoint;

    public DeleteResourceCommandHandler(IRepositoryAsync<Resource> repositoryAsync, IPublishEndpoint publishEndpoint)
    {
        _repositoryAsync = repositoryAsync;
        _publishEndpoint = publishEndpoint;
    }

    public Task<Wrappers.Response<Guid>> Handle(DeleteResourceCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new KeyNotFoundException();

        return ProcessHandle(request, cancellationToken);
    }

    public async Task<Wrappers.Response<Guid>> ProcessHandle(DeleteResourceCommand request, CancellationToken cancellationToken)
    {
        var resource = await _repositoryAsync.GetByIdAsync(request.Id, cancellationToken);
        if (resource is null)
            throw new ApiException($"Record with id {request.Id} not found");

        resource.State = false;

        await _repositoryAsync.UpdateAsync(resource);
        
        await PublishResourceDeleted(request.ToResourceDeleted(), cancellationToken);

        return new Wrappers.Response<Guid>(resource.Id);
    }
    
    private async Task PublishResourceDeleted(ResourceDeleted request, CancellationToken cancellationToken)
    {
        await _publishEndpoint.Publish(
            request,
            ctx =>
            {
                ctx.MessageId = request.Id;
                ctx.SetRoutingKey("resource.deleted");
            },
            cancellationToken);
    }
}
