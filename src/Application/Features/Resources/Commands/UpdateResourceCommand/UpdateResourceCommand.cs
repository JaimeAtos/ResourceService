using Application.Exceptions;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Resources.Commands.UpdateResourceCommand;
public class UpdateResourceCommand : IRequest<Response<Guid>>
{
    public Guid Id { get; set; }
    public string ResourceName { get; set; }
    public string? ResumeUrl { get; set; }
    public string WorkEmail { get; set; }
    public string PersonalEmail { get; set; }
    public string Phone { get; set; }
    public string CurrentStateDescription { get; set; }
    public string CurrentPositionDescription { get; set; }
    public Guid LocationId { get; set; }
    public string LocationDescription { get; set; }
    public string NessieID { get; set; }
    public string CurrentClientName { get; set; }
    public bool IsNational { get; set; }
    public byte Gcm {get ; set;}
}

public class UpdateResourceCommandHandler : IRequestHandler<UpdateResourceCommand, Response<Guid>>
{
    private readonly IRepositoryAsync<Resource> _repositoryAsync;
    private readonly IMapper _mapper;

    public UpdateResourceCommandHandler(IRepositoryAsync<Resource> repositoryAsync, IMapper mapper)
    {
        _repositoryAsync=repositoryAsync;
        _mapper=mapper;
    }

    public Task<Response<Guid>> Handle(UpdateResourceCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new KeyNotFoundException();

        return ProcessHandle(request, cancellationToken);

    }

    public async Task<Response<Guid>> ProcessHandle(UpdateResourceCommand request, CancellationToken cancellationToken)
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
        resource.CurrentPositionDescription = request.CurrentPositionDescription;
        resource.LocationId = request.LocationId;
        resource.LocationDescription = request.LocationDescription;
        resource.NessieID = request.NessieID;
        resource.CurrentClientName = request.CurrentClientName;
        resource.IsNational = request.IsNational;
        resource.Gcm = request.Gcm;

        await _repositoryAsync.UpdateAsync(resource);

        return new Response<Guid>(resource.Id);
    }
}