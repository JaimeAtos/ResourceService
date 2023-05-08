using Application.Interfaces;
using Atos.Core.EventsDTO;
using Domain.Entities;
using MassTransit;

namespace Application.Consumers.ScreeningResourceExtraSkill;

public class ScreeningResourceExtraSkillCreatedConsumer : IConsumer<ScreeningResourceExtraSkillCreated>
{
    private readonly IRepositoryAsync<ResourceExtraSkills> _repository;

    public ScreeningResourceExtraSkillCreatedConsumer(IRepositoryAsync<ResourceExtraSkills> repository)
    {
        _repository = repository;
    }

    public async Task Consume(ConsumeContext<ScreeningResourceExtraSkillCreated> context)
    {
        var message = context.Message;
        var resourceExtraSkills = new ResourceExtraSkills
        {
            Title = message.Title,
            ResourceId = message.ResourceId,
            ExperienceOverallTypeTag = message.ExperienceOverallTypeTag,
            BriefDescription = message.BriefDescription,
            Point = message.ScreeningPoint,
            IsApproved = message.IsApproved
        };

        await _repository.AddAsync(resourceExtraSkills);
    }
}