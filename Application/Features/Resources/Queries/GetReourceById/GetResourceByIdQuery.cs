using Application.DTOs;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Resources.Queries.GetReourceById;

public class GetResourceByIdQuery : IRequest<Response<ResourceDto>>
{
    public Guid Id { get; set; }
}
public class GetResourceByIdQueryHandler : IRequestHandler<GetResourceByIdQuery, Response<ResourceDto>>
{
    private readonly IRepositoryAsync<Resource> _repositoryAsync;
    private readonly IMapper _mapper;

    public GetResourceByIdQueryHandler(IMapper mapper, IRepositoryAsync<Resource> repositoryAsync)
    {
        _mapper=mapper;
        _repositoryAsync=repositoryAsync;
    }

    public Task<Response<ResourceDto>> Handle(GetResourceByIdQuery request, CancellationToken cancellationToken)
    {
        
        if (request == null)
            throw new ArgumentNullException();
        return ProcessHandle(request, cancellationToken);
    }

    public async Task<Response<ResourceDto>> ProcessHandle(GetResourceByIdQuery request, CancellationToken cancellationToken)
    {
        var resource = await _repositoryAsync.GetByIdAsync(request.Id);
        if (resource == null)
            throw new KeyNotFoundException($"Record with id {request.Id} not found");
        else
        {
            var dto = _mapper.Map<ResourceDto>(resource);
            return new Response<ResourceDto>(dto);
        }
    }
}