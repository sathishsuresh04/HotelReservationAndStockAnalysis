using HotelReservation.Reservations.Features.ReserveRoom;
using HotelReservation.Shared.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace HotelReservation.Shared;

public static class HotelReservationConfigs
{
    private const string ReservationsTag = "Reservations";
    private const string Reservations = "reservations";
    private const string BaseApiPath = "api/v{version:apiVersion}";
    private static string ReservationPrefixUri => $"{BaseApiPath}/{Reservations}";

    public static WebApplicationBuilder AddReservationManagementServices(this WebApplicationBuilder builder)
    {
        builder.AddInfrastructure();
        return builder;
    }

    public static WebApplication UseReservationManagementServices(this WebApplication app)
    {
        app.UseInfrastructure();
        return app;
    }

    public static IEndpointRouteBuilder MapReservationManagementEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/", () => "Reservation Service").ExcludeFromDescription();
        endpoints.MapReservationModuleEndpoints();
        return endpoints;
    }

    private static IEndpointRouteBuilder MapReservationModuleEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var reservationsV1 = endpoints.NewVersionedApi(ReservationsTag)
            .MapGroup(ReservationPrefixUri)
            .HasDeprecatedApiVersion(0.9)
            .HasApiVersion(1.0);

        reservationsV1.MapReserveRoomEndpoint();

        return endpoints;
    }
}