using Application.Interfaces;
using Atos.Core.EventsDTO;
using Domain.Entities;
using MassTransit;

namespace Application.Consumers.ClientConsumers;

public class ClientUpdatedConsumer : IConsumer<ClientUpdated>
{
    private readonly IRepositoryAsync<Resource> _repository;

    public ClientUpdatedConsumer(IRepositoryAsync<Resource>  repository)
    {
        _repository = repository;
    }
    
    public async  Task Consume(ConsumeContext<ClientUpdated> context)
    {
        var message = context.Message;
        var resources = await _repository.ListAsync();

        foreach (var resource in resources.Where(s => s.CurrentClientId == message.Id))
        {
            resource.CurrentClientName = message.Name;
            await _repository.UpdateAsync(resource);
        }
    }
}