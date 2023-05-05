using Application.Interfaces;
using Atos.Core.EventsDTO;
using Domain.Entities;
using MassTransit;

namespace Application.Consumers.CatalogStateConsumers;

public class CatalogStateDeletedConsumer : IConsumer<CatalogStateDeleted>
{
    private readonly IRepositoryAsync<Resource> _repository;

    public CatalogStateDeletedConsumer(IRepositoryAsync<Resource> repository)
    {
        _repository = repository;
    }
    
    public async Task Consume(ConsumeContext<CatalogStateDeleted> context)
    {
        var message = context.Message;
        var resources = await _repository.ListAsync();

        foreach (var resource in resources.Where(s => s.CurrentStateId == message.Id))
        {
            // Podría ser un guid empty pero si el id es unique no deberíamos hacer esto
            resource.CurrentStateId = Guid.Empty;
            resource.CurrentStateDescription = null;
            await _repository.UpdateAsync(resource);
        }
    }
}