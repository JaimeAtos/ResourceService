using Application.Exceptions;
using Application.Interfaces;
using Application.Wrappers;
using Domain.Entities;
using MediatR;

namespace Application.Features.ResourcesSkills.Commands.UpdateResourceSkillCommand;

public class UpdateResourceSkillsCommand : IRequest<Response<Guid>>
{
    public Guid Id { get; set; }
    public Guid ResourceId { get; set; }
    public Guid SkillId { get; set; }
    public string SkillName { get; set; }
    public string SkillAcceptanceURL { get; set; } // Evidences of Validations
    public bool IsCompliance { get; set; } // False if resource needs to revalidate the skill
}

public class UpdateResourceSkillsCommandHandler : IRequestHandler<UpdateResourceSkillsCommand, Response<Guid>>
{
    private readonly IRepositoryAsync<ResourceSkills> _repository;

    public UpdateResourceSkillsCommandHandler(IRepositoryAsync<ResourceSkills> repository)
    {
        _repository=repository;
    }

    public async Task<Response<Guid>> Handle(UpdateResourceSkillsCommand request, CancellationToken cancellationToken)
    {
        if(request is null)
            throw new ArgumentNullException();

        var resourceSkills = await _repository.GetByIdAsync(request.Id);
        if (resourceSkills is null)
            throw new ApiException($"Record with id {request.Id} not founded");

        resourceSkills.ResourceId = request.ResourceId;
        resourceSkills.SkillId = request.SkillId;
        resourceSkills.SkillName = request.SkillName;
        resourceSkills.SkillAcceptanceURL = request.SkillAcceptanceURL;
        resourceSkills.IsCompliance = request.IsCompliance;

        await _repository.UpdateAsync(resourceSkills);

        return new Response<Guid>(resourceSkills.Id);
    }
}