using Application.Interfaces;
using Atos.Core.EventsDTO;
using Domain.Entities;
using MassTransit;

namespace Application.Consumers.CatalogLocationConsumers;

public class CatalogLocationDeletedConsumer : IConsumer<CatalogLocationDeleted>
{
    private readonly IRepositoryAsync<Resource> _repository;

    public CatalogLocationDeletedConsumer(IRepositoryAsync<Resource> repository)
    {
        _repository = repository;
    }
    
    public async Task Consume(ConsumeContext<CatalogLocationDeleted> context)
    {
        var message = context.Message;
        var resources = await _repository.ListAsync();

        foreach (var resource in resources.Where(s => s.LocationId == message.LocationId))
        {
            // Podría ser un guid empty pero si el id es unique no deberíamos hacer esto
            resource.LocationId = Guid.Empty;
            resource.LocationDescription = null;
            await _repository.UpdateAsync(resource);
        }
    }
}