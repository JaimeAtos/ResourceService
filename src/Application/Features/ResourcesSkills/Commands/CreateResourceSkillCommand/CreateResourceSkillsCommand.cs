using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ResourcesSkills.Commands.CreateResourceSkillCommand;

public class CreateResourceSkillsCommand : IRequest<Response<Guid>>
{
    public Guid ResourceId { get; set; }
    public string SkillName { get; set; }
    public string SkillAcceptanceURL { get; set; } // Evidences of Validations
    public bool IsCompliance { get; set; } // False if resource needs to revalidate the skill
}

public class CreateResourceSkillsCommandHandler : IRequestHandler<CreateResourceSkillsCommand, Response<Guid>>
{
    private readonly IRepositoryAsync<ResourceSkills> _repository;
    private readonly IMapper _mapper;

    public CreateResourceSkillsCommandHandler(IRepositoryAsync<ResourceSkills> repository, IMapper mapper)
    {
        _repository=repository;
        _mapper=mapper;
    }

    public async Task<Response<Guid>> Handle(CreateResourceSkillsCommand request, CancellationToken cancellationToken)
    {
        var resourceSkills = _mapper.Map<ResourceSkills>(request);
        var data = await _repository.AddAsync(resourceSkills);

        return new Response<Guid>(data.Id);
    }
}