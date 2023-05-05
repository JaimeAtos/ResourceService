using Application.Interfaces;
using Atos.Core.EventsDTO;
using Domain.Entities;
using MassTransit;

namespace Application.Consumers.PositionConsumers;

public class PositionDeletedConsumer : IConsumer<PositionDeleted>
{
    private readonly IRepositoryAsync<Resource> _repository;

    public PositionDeletedConsumer(IRepositoryAsync<Resource>  repository)
    {
        _repository = repository;
    }
    
    public async  Task Consume(ConsumeContext<PositionDeleted> context)
    {
        var message = context.Message;
        var resources = await _repository.ListAsync();

        foreach (var resource in resources.Where(s => s.CurrentPositionId == message.Id))
        {
            // Podría ser un guid empty pero si el id es unique no deberíamos hacer esto
            resource.CurrentPositionId = Guid.Empty;
            resource.CurrentPositionDescription = null;
            await _repository.UpdateAsync(resource);
        }
    }
}