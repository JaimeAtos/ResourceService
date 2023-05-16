using Application.Interfaces;
using Atos.Core.EventsDTO;
using Domain.Entities;
using MassTransit;

namespace Application.Consumers.SkillConsumers;

public class SkillDeletedConsumer : IConsumer<SkillDeleted>
{
    private readonly IRepositoryAsync<ResourceSkills> _repository;

    public SkillDeletedConsumer(IRepositoryAsync<ResourceSkills>  repository)
    {
        _repository = repository;
    }
    
    public async Task Consume(ConsumeContext<SkillDeleted> context)
    {
        var message = context.Message;
        var resourceSkills = await _repository.ListAsync();

        foreach (var resourceSkill in resourceSkills.Where(s => s.SkillId == message.Id))
        {
            resourceSkill.State = false;
            await _repository.UpdateAsync(resourceSkill);
        }
    }
}