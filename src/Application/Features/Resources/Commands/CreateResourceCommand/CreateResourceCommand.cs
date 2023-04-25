using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Resources.Commands.CreateResourceCommand;
public class CreateResourceCommand : IRequest<Response<Guid>>
{
    public string ResourceName { get; set; }
    public string? ResumeUrl { get; set; }
    public string? WorkEmail { get; set; }
    public string PersonalEmail { get; set; }
    public string Phone { get; set; }
    public string CurrentStateDescription { get; set; }
    public string CurrentPositionDescription { get; set; }
    public Guid LocationId { get; set; }
    public string LocationDescription { get; set; }
    public string? NessieID { get; set; }
    public string CurrentClientName { get; set; }
    public bool IsNational { get; set; }
    public byte Gcm {get ; set;}
}

public class CreateResourceCommandHandler : IRequestHandler<CreateResourceCommand, Response<Guid>>
{
    private readonly IRepositoryAsync<Resource> _repositoryAsync;
    private readonly IMapper _mapper;

    public CreateResourceCommandHandler(IRepositoryAsync<Resource> repositoryAsync, IMapper mapper)
    {
        _repositoryAsync=repositoryAsync;
        _mapper=mapper;
    }

    public async Task<Response<Guid>> Handle(CreateResourceCommand request, CancellationToken cancellationToken)
    {
        var newRecord = _mapper.Map<Resource>(request);
        var data = await _repositoryAsync.AddAsync(newRecord);

        return new Response<Guid>(data.Id);
    }
}