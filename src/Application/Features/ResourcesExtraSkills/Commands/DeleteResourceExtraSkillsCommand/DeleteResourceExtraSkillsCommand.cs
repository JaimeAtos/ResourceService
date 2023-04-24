using Application.Exceptions;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ResourcesExtraSkills.DeleteResourceExtraSkillsCommand;

public class DeleteResourceExtraSkillsCommand : IRequest<Response<Guid>>
{
    public Guid Id { get; set; }
}

public class DeleteResourceExtraSkillsCommandHandler : IRequestHandler<DeleteResourceExtraSkillsCommand, Response<Guid>>
{
    private readonly IRepositoryAsync<ResourceExtraSkills> _repositoryAsync;
    private readonly IMapper _mapper;

    public DeleteResourceExtraSkillsCommandHandler(IRepositoryAsync<ResourceExtraSkills> repositoryAsync, IMapper mapper)
    {
        _repositoryAsync=repositoryAsync;
        _mapper=mapper;
    }

    public Task<Response<Guid>> Handle(DeleteResourceExtraSkillsCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new KeyNotFoundException();

        return ProcessHandle(request, cancellationToken);

    }

    public async Task<Response<Guid>> ProcessHandle(DeleteResourceExtraSkillsCommand request, CancellationToken cancellationToken)
    {
        var resourceExtraSkills = await _repositoryAsync.GetByIdAsync(request.Id);
        if (resourceExtraSkills is null)
            throw new ApiException($"Record with id {request.Id} not founded");

        resourceExtraSkills.State = false;

        await _repositoryAsync.UpdateAsync(resourceExtraSkills);

        return new Response<Guid>(resourceExtraSkills.Id);
    }
}

