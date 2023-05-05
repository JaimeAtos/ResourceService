using Application.Interfaces;
using Atos.Core.EventsDTO;
using Domain.Entities;
using MassTransit;

namespace Application.Consumers.ClientConsumers;

public class ClientDeletedConsumer : IConsumer<ClientDeleted>
{
    private readonly IRepositoryAsync<Resource> _repository;

    public ClientDeletedConsumer(IRepositoryAsync<Resource>  repository)
    {
        _repository = repository;
    }
    
    public async  Task Consume(ConsumeContext<ClientDeleted> context)
    {
        var message = context.Message;
        var resources = await _repository.ListAsync();

        foreach (var resource in resources.Where(s => s.CurrentClientId == message.Id))
        {
            // Podría ser un guid empty pero si el id es unique no deberíamos hacer esto
            resource.CurrentClientId = Guid.Empty;
            resource.CurrentClientName = null;
            await _repository.UpdateAsync(resource);
        }
    }
}