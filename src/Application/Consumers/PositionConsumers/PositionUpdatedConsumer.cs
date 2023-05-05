using Application.Interfaces;
using Atos.Core.EventsDTO;
using Domain.Entities;
using MassTransit;

namespace Application.Consumers.PositionConsumers;

public class PositionUpdatedConsumer : IConsumer<PositionUpdated>
{
    private readonly IRepositoryAsync<Resource> _repository;

    public PositionUpdatedConsumer(IRepositoryAsync<Resource> repository)
    {
        _repository = repository;
    }
    
    public async Task Consume(ConsumeContext<PositionUpdated> context)
    {
        var message = context.Message;
        var resources = await _repository.ListAsync();

        foreach (var resource in resources.Where(s => s.CurrentPositionId == message.Id))
        {
            resource.CurrentPositionDescription = message.Description;
            await _repository.UpdateAsync(resource);
        }
    }
}