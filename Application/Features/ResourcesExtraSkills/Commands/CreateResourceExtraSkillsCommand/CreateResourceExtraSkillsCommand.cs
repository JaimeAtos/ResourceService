using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ResourcesExtraSkills.CreateResourceExtraSkillsCommand;

public class CreateResourceExtraSkillsCommand : IRequest<Response<Guid>>
{
    public string FullName { get; set; }
    public string Title { get; set; }
    public string ResourceId { get; set; }
    public string ExperienceOveralTypeTag { get; set; } //Certification, Course,
    public string BriefDescription { get; set; }
    public byte Point { get; set; } // 0 to 100. This field is used by the mentor to validate the experience
    public bool IsApproved { get; set; }
}

public class CreateResourceExtraSkillsCommandHandler : IRequestHandler<CreateResourceExtraSkillsCommand, Response<Guid>>
{
    private readonly IRepositoryAsync<ResourceExtraSkills> _repositoryAsync;
    private readonly IMapper _mapper;

    public CreateResourceExtraSkillsCommandHandler(IRepositoryAsync<ResourceExtraSkills> repositoryAsync, IMapper mapper)
    {
        _repositoryAsync=repositoryAsync;
        _mapper=mapper;
    }

    public async Task<Response<Guid>> Handle(CreateResourceExtraSkillsCommand request, CancellationToken cancellationToken)
    {
        var newRecord = _mapper.Map<ResourceExtraSkills>(request);
        var data = await _repositoryAsync.AddAsync(newRecord);

        return new Response<Guid>(data.Id);
    }
}
