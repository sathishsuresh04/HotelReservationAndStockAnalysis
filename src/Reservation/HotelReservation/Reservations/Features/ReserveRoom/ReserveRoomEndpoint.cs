using HotelReservation.Shared.Extensions;
using Humanizer;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace HotelReservation.Reservations.Features.ReserveRoom;

internal static class ReserveRoomEndpoint
{
    internal static RouteHandlerBuilder MapReserveRoomEndpoint(this IEndpointRouteBuilder builder)
    {
        return builder.MapPost(
                "/reserve",
                async Task<IResult> (
                    ReserveRoom command,
                    IMediator mediator) =>
                {
                    var result = await mediator.Send(command);
                    return result
                        ? Results.Ok("Room reserved successfully.")
                        : Results.BadRequest("Room is already reserved.");
                })
            .WithName("ReserveRoom")
            .WithDisplayName(nameof(ReserveRoom).Humanize())
            .WithDisplayName("Reserve Room Endpoint")
            .WithSummaryAndDescription(
                "Reserves a specific room",
                "Reserves the room identified by the specified room identifier")
            .Produces<string>()
            .Produces<ValidationProblemDetails>(StatusCodes.Status400BadRequest)
            .ProducesProblem(
                "An error occurred while reserving the room.",
                StatusCodes.Status500InternalServerError);
    }
}