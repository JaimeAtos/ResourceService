using Application.Interfaces;
using Atos.Core.EventsDTO;
using Domain.Entities;
using MassTransit;

namespace Application.Consumers.SkillConsumers;

public class SkillUpdatedConsumer : IConsumer<SkillUpdated>
{
    private readonly IRepositoryAsync<ResourceSkills> _repository;

    public SkillUpdatedConsumer(IRepositoryAsync<ResourceSkills>  repository)
    {
        _repository = repository;
    }
    
    public async Task Consume(ConsumeContext<SkillUpdated> context)
    {
        var message = context.Message;
        var resourceSkills = await _repository.ListAsync();

        foreach (var resourceSkill in resourceSkills.Where(s => s.SkillId == message.Id))
        {
            resourceSkill.SkillName = message.Description;
            await _repository.UpdateAsync(resourceSkill);
        }
    }
}