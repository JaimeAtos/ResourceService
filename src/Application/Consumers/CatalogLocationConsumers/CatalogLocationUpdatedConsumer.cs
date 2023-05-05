using Application.Interfaces;
using Atos.Core.EventsDTO;
using Domain.Entities;
using MassTransit;

namespace Application.Consumers.CatalogLocationConsumers;

public class CatalogLocationUpdatedConsumer : IConsumer<CatalogLocationUpdated>
{
    private readonly IRepositoryAsync<Resource> _repository;

    public CatalogLocationUpdatedConsumer(IRepositoryAsync<Resource> repository)
    {
        _repository = repository;
    }
    
    public async Task Consume(ConsumeContext<CatalogLocationUpdated> context)
    {
        var message = context.Message;
        var resources = await _repository.ListAsync();

        foreach (var resource in resources.Where(s => s.LocationId == message.LocationId))
        {
            resource.LocationDescription = $"{message.CityDescription} - {message.CountryDescription}";
            await _repository.UpdateAsync(resource);
        }
    }
}