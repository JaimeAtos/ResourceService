using Application.Exceptions;
using Application.Extensions;
using Application.Interfaces;
using Atos.Core.Abstractions.Publishers;
using Atos.Core.EventsDTO;
using Domain.Entities;
using MassTransit;
using MediatR;

namespace Application.Features.Resources.Commands.UpdateResourceCommand;
public class UpdateResourceCommand : IRequest<Wrappers.Response<Guid>>
{
    public Guid Id { get; set; }
    public string ResourceName { get; set; }
    public string? ResumeUrl { get; set; }
    public string? WorkEmail { get; set; }
    public string PersonalEmail { get; set; }
    public string Phone { get; set; }
    public string CurrentStateDescription { get; set; }
    public Guid CurrentStateId { get; set; }
    public string CurrentPositionDescription { get; set; }
    public Guid CurrentPositionId { get; set; }
    public string LocationDescription { get; set; }
    public Guid LocationId { get; set; }
    public string? NessieID { get; set; }
    public string CurrentClientName { get; set; }
    public Guid CurrentClientId { get; set; }
    public bool IsNational { get; set; }
    public byte Gcm {get ; set;}
}

public class UpdateResourceCommandHandler : IRequestHandler<UpdateResourceCommand, Wrappers.Response<Guid>>
{
    private readonly IRepositoryAsync<Resource> _repositoryAsync;
    private readonly IPublisherCommands<ResourceUpdated> _publisherCommands;

    public UpdateResourceCommandHandler(IRepositoryAsync<Resource> repositoryAsync, IPublisherCommands<ResourceUpdated> publisherCommands)
    {
        _repositoryAsync=repositoryAsync;
        _publisherCommands = publisherCommands;
    }

    public Task<Wrappers.Response<Guid>> Handle(UpdateResourceCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new KeyNotFoundException();

        return ProcessHandle(request, cancellationToken);
    }

    public async Task<Wrappers.Response<Guid>> ProcessHandle(UpdateResourceCommand request, CancellationToken cancellationToken)
    {
        var resource = await _repositoryAsync.GetByIdAsync(request.Id);
        if (resource is null)
            throw new ApiException($"Record with id {request.Id} not founded");
        
        resource.ResourceName = request.ResourceName;
        resource.ResumeUrl = request.ResumeUrl;
        resource.WorkEmail = request.WorkEmail;
        resource.PersonalEmail = request.PersonalEmail;
        resource.Phone = request.Phone;
        resource.CurrentStateDescription = request.CurrentStateDescription;
        resource.CurrentStateId = request.CurrentStateId;
        resource.CurrentPositionDescription = request.CurrentPositionDescription;
        resource.CurrentPositionId = request.CurrentPositionId;
        resource.LocationId = request.LocationId;
        resource.LocationDescription = request.LocationDescription;
        resource.NessieID = request.NessieID;
        resource.CurrentClientName = request.CurrentClientName;
        resource.CurrentClientId = request.CurrentClientId;
        resource.IsNational = request.IsNational;
        resource.Gcm = request.Gcm;

        await _repositoryAsync.UpdateAsync(resource);
        await _publisherCommands.PublishEntityMessage(request.ToResourceUpdated(), "resource.updated", request.Id, cancellationToken);

        return new Wrappers.Response<Guid>(resource.Id);
    }
    
}