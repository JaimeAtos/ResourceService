using Application.Exceptions;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Resources.Commands.DeleteResourceCommand;
public class DeleteResourceCommand : IRequest<Response<Guid>>
{
    public Guid Id { get; set; }
}

public class DeleteResourceCommandHandler : IRequestHandler<DeleteResourceCommand, Response<Guid>>
{
    private readonly IRepositoryAsync<Resource> _repositoryAsync;
    private readonly IMapper _mapper;

    public DeleteResourceCommandHandler(IRepositoryAsync<Resource> repositoryAsync, IMapper mapper)
    {
        _repositoryAsync=repositoryAsync;
        _mapper=mapper;
    }

    public Task<Response<Guid>> Handle(DeleteResourceCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new KeyNotFoundException();

        return ProcessHandle(request, cancellationToken);

    }

    public async Task<Response<Guid>> ProcessHandle(DeleteResourceCommand request, CancellationToken cancellationToken)
    {
        var resource = await _repositoryAsync.GetByIdAsync(request.Id);
        if (resource is null)
            throw new ApiException($"Record with id {request.Id} not found");

        resource.State = false;

        await _repositoryAsync.UpdateAsync(resource);

        return new Response<Guid>(resource.Id);
    }
}
