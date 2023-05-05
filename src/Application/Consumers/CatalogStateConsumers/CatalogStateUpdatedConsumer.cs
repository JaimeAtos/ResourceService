using Application.Interfaces;
using Atos.Core.EventsDTO;
using Domain.Entities;
using MassTransit;

namespace Application.Consumers.CatalogStateConsumers;

public class CatalogStateUpdatedConsumer : IConsumer<CatalogStateUpdated>
{
    private readonly IRepositoryAsync<Resource> _repository;

    public CatalogStateUpdatedConsumer(IRepositoryAsync<Resource> repository)
    {
        _repository = repository;
    }


    public async Task Consume(ConsumeContext<CatalogStateUpdated> context)
    {
        var message = context.Message;
        var resources = await _repository.ListAsync();

        foreach (var resource in resources.Where(s => s.CurrentStateId == message.Id))
        {
            resource.CurrentStateDescription = message.Description;
            await _repository.UpdateAsync(resource);
        }
    }
}