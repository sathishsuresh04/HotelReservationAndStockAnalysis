using System.Reflection;
using FluentValidation;
using HotelReservation.Shared.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Scrutor;

namespace HotelReservation.Shared.Extensions;

public static class AddInfrastructureExtensions
{
    public static WebApplicationBuilder AddInfrastructure(this WebApplicationBuilder builder)
    {
        builder.Services
            .Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true)
            .AddCustomMediatR()
            .AddExceptionHandler<GlobalExceptionHandler>()
            .AddProblemDetails()
            .AddEndpointsApiExplorer()
            .AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Reservation Management Service", Version = "v1" });
                c.EnableAnnotations(); // Enable annotations for better documentation
            })
            .AddCustomVersioning()
            .AddCustomValidators(typeof(IHotelReservationRoot).Assembly);
        return builder;
    }
    
    private static IServiceCollection AddCustomMediatR(this IServiceCollection services)
    {
        services.AddMediatR(
            cfg =>
            {
                cfg.RegisterServicesFromAssemblyContaining(typeof(IHotelReservationRoot));
            });
        return services;
    }
    
    public static IServiceCollection AddCustomValidators(
        this IServiceCollection services,
        Assembly assembly,
        ServiceLifetime serviceLifetime = ServiceLifetime.Transient
    )
    {
        services.Scan(
            scan =>
                scan.FromAssemblies(assembly)
                    .AddClasses(classes => classes.AssignableTo(typeof(IValidator<>)))
                    .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                    .AsImplementedInterfaces()
                    .WithLifetime(serviceLifetime));

        return services;
    }
}