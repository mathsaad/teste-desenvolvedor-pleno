using System.Reflection;
using FluentValidation;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using Products.Application.Behaviors;
using Products.Application.Mappings;

namespace Products.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cf =>
        {
            cf.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            cf.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });
        
        MappingConfig.Configure();
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());
        services.AddSingleton(config);

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
}