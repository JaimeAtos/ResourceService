using Application.Behaviours;
using Application.Features.Resources.Commands.CreateResourceCommand;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Application.Consumers.CatalogLocationConsumers;
using Application.Consumers.CatalogStateConsumers;
using Application.Consumers.ClientConsumers;
using Application.Consumers.PositionConsumers;
using Application.Consumers.ScreeningResourceExtraSkill;
using Application.Consumers.SkillConsumers;
using Atos.Core.Abstractions.Publishers;
using Atos.Core.Commons.Publishers;
using Atos.Core.EventsDTO;
using MassTransit;

namespace Application;

public static class DependencyContainer
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreateResourceCommand>());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        services.AddScoped<IPublisherCommands<ResourceUpdated>, PublisherCommands<ResourceUpdated>>();
        services.AddScoped<IPublisherCommands<ResourceDeleted>, PublisherCommands<ResourceDeleted>>();
        services
            .AddScoped<IPublisherCommands<ResourceExtraSkillUpdated>, PublisherCommands<ResourceExtraSkillUpdated>>();
        services
            .AddScoped<IPublisherCommands<ResourceExtraSkillDeleted>, PublisherCommands<ResourceExtraSkillDeleted>>();
        services.AddMassTransit();

        return services;
    }

    public static IServiceCollection AddMassTransit(this IServiceCollection services)
    {
        services.AddMassTransit(cfg =>
        {
            cfg.AddConsumer<SkillUpdatedConsumer>();
            cfg.AddConsumer<SkillDeletedConsumer>();
            cfg.AddConsumer<PositionUpdatedConsumer>();
            cfg.AddConsumer<PositionDeletedConsumer>();
            cfg.AddConsumer<ClientUpdatedConsumer>();
            cfg.AddConsumer<ClientDeletedConsumer>();
            cfg.AddConsumer<CatalogLocationUpdatedConsumer>();
            cfg.AddConsumer<CatalogLocationDeletedConsumer>();
            cfg.AddConsumer<CatalogStateUpdatedConsumer>();
            cfg.AddConsumer<CatalogStateDeletedConsumer>();
            cfg.AddConsumer<ScreeningResourceExtraSkillCreatedConsumer>();

            cfg.UsingRabbitMq((ctx, cfgrmq) =>
            {
                cfgrmq.Host(GetMessageBrokerUrl());

                cfgrmq.ReceiveEndpoint("ResourceServiceQueue", econfigureEndpoint =>
                {
                    econfigureEndpoint.ConfigureConsumeTopology = false;
                    econfigureEndpoint.Durable = true;

                    // El ConfigureConsumer debe ir después del durable y la topology
                    econfigureEndpoint.ConfigureConsumer<SkillUpdatedConsumer>(ctx);
                    econfigureEndpoint.ConfigureConsumer<SkillDeletedConsumer>(ctx);
                    econfigureEndpoint.ConfigureConsumer<PositionUpdatedConsumer>(ctx);
                    econfigureEndpoint.ConfigureConsumer<PositionDeletedConsumer>(ctx);
                    econfigureEndpoint.ConfigureConsumer<ClientUpdatedConsumer>(ctx);
                    econfigureEndpoint.ConfigureConsumer<ClientDeletedConsumer>(ctx);
                    econfigureEndpoint.ConfigureConsumer<CatalogLocationUpdatedConsumer>(ctx);
                    econfigureEndpoint.ConfigureConsumer<CatalogLocationDeletedConsumer>(ctx);
                    econfigureEndpoint.ConfigureConsumer<CatalogStateUpdatedConsumer>(ctx);
                    econfigureEndpoint.ConfigureConsumer<CatalogStateDeletedConsumer>(ctx);
                    econfigureEndpoint.ConfigureConsumer<ScreeningResourceExtraSkillCreatedConsumer>(ctx);

                    econfigureEndpoint.UseMessageRetry(retryConfigure =>
                    {
                        retryConfigure.Interval(5, TimeSpan.FromMilliseconds(1000));
                    });
                    econfigureEndpoint.Bind("Atos.Core.EventsDTO:SkillUpdated", d =>
                    {
                        d.ExchangeType = "topic";
                        d.RoutingKey = "skill.updated";
                    });
                    econfigureEndpoint.Bind("Atos.Core.EventsDTO:SkillDeleted", d =>
                    {
                        d.ExchangeType = "topic";
                        d.RoutingKey = "skill.deleted";
                    });
                    econfigureEndpoint.Bind("Atos.Core.EventsDTO:PositionUpdated", d =>
                    {
                        d.ExchangeType = "topic";
                        d.RoutingKey = "position.updated";
                    });
                    econfigureEndpoint.Bind("Atos.Core.EventsDTO:PositionDeleted", d =>
                    {
                        d.ExchangeType = "topic";
                        d.RoutingKey = "position.deleted";
                    });
                    econfigureEndpoint.Bind("Atos.Core.EventsDTO:ClientUpdated", d =>
                    {
                        d.ExchangeType = "topic";
                        d.RoutingKey = "client.updated";
                    });
                    econfigureEndpoint.Bind("Atos.Core.EventsDTO:ClientDeleted", d =>
                    {
                        d.ExchangeType = "topic";
                        d.RoutingKey = "client.deleted";
                    });
                    econfigureEndpoint.Bind("Atos.Core.EventsDTO:CatalogLocationUpdated", d =>
                    {
                        d.ExchangeType = "topic";
                        d.RoutingKey = "catalog.location.updated";
                    });
                    econfigureEndpoint.Bind("Atos.Core.EventsDTO:CatalogLocationDeleted", d =>
                    {
                        d.ExchangeType = "topic";
                        d.RoutingKey = "catalog.location.deleted";
                    });
                    econfigureEndpoint.Bind("Atos.Core.EventsDTO:CatalogStateUpdated", d =>
                    {
                        d.ExchangeType = "topic";
                        d.RoutingKey = "catalog.state.updated";
                    });
                    econfigureEndpoint.Bind("Atos.Core.EventsDTO:CatalogStateDeleted", d =>
                    {
                        d.ExchangeType = "topic";
                        d.RoutingKey = "catalog.state.deleted";
                    });
                    econfigureEndpoint.Bind("Atos.Core.EventsDTO:ScreeningResourceExtraSkillCreated", d =>
                    {
                        d.ExchangeType = "topic";
                        d.RoutingKey = "screeningResourceExtraSkill.created";
                    });
                });

                cfgrmq.Publish<ResourceUpdated>(x => { x.ExchangeType = "topic"; });
                cfgrmq.Publish<ResourceDeleted>(x => { x.ExchangeType = "topic"; });
                cfgrmq.Publish<ResourceExtraSkillUpdated>(x => { x.ExchangeType = "topic"; });
                cfgrmq.Publish<ResourceExtraSkillDeleted>(x => { x.ExchangeType = "topic"; });
            });
        });
        return services;
    }

    private static string GetMessageBrokerUrl()
    {
        var messageBrokerHost = Environment.GetEnvironmentVariable("MQHOST");
        var messageBrokerPort = Environment.GetEnvironmentVariable("MQPORT");
        var user = Environment.GetEnvironmentVariable("MQUSER");
        var password = Environment.GetEnvironmentVariable("MQPASSWORD");
        var url = $"amqp://{user}:{password}@{messageBrokerHost}:{messageBrokerPort}";
        return url;
    }
}