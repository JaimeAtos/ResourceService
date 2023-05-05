using Application.Exceptions;
using Application.Interfaces;
using Application.Wrappers;
using Domain.Entities;
using MediatR;

namespace Application.Features.ResourcesSkills.Commands.DeleteResourceSkillCommand;

public class DeleteResourceSkillsCommand : IRequest<Response<Guid>>
{
    public Guid Id { get; set; }
}

public class DeleteResourceSkillsCommandHandler : IRequestHandler<DeleteResourceSkillsCommand, Response<Guid>>
{
    private readonly IRepositoryAsync<ResourceSkills> _repository;

    public DeleteResourceSkillsCommandHandler(IRepositoryAsync<ResourceSkills> repository)
    {
        _repository=repository;
    }

    public async Task<Response<Guid>> Handle(DeleteResourceSkillsCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new ArgumentNullException();

        var resourceSkills = await _repository.GetByIdAsync(request.Id);
        if (resourceSkills is null)
            throw new ApiException($"Record with id {request.Id} not founded");

        resourceSkills.State = false;

        await _repository.UpdateAsync(resourceSkills);

        return new Response<Guid>(resourceSkills.Id);
    }
}
