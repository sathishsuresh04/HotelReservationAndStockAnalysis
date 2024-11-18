using System.Text.Json;
using FluentValidation;
using HotelReservation.Reservations.Models;
using HotelReservation.Reservations.ValueObjects;
using HotelReservation.Shared.Validation;
using MediatR;
using ValidationException = HotelReservation.Shared.Exceptions.ValidationException;

namespace HotelReservation.Reservations.Features.ReserveRoom;

public record ReserveRoom(string RoomIdentifier) : IRequest<bool>;

public class ReserveRoomCommandValidator : AbstractValidator<ReserveRoom>
{
    public ReserveRoomCommandValidator()
    {
        RuleFor(x => x.RoomIdentifier).NotEmpty().WithMessage("Room identifier must not be empty.")
            .Matches(@"^[^\-]+-[^\-]+$").WithMessage("Room identifier must be in the format 'HotelName-RoomNumber'.");
    }
}

public class ReserveRoomHandler(IValidator<ReserveRoom> validator) : IRequestHandler<ReserveRoom, bool>
{
    public async Task<bool> Handle(ReserveRoom request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        //Can be moved to mediatr pipeline
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors
                    .ConvertAll(error => new ValidationError(error.PropertyName, error.ErrorMessage))
                ;
            var message = JsonSerializer.Serialize(errors);
            throw new ValidationException(message);
        }

        var room = Room.Create(request.RoomIdentifier);
        var result = Reservation.Reserve(room);
        return await Task.FromResult(result);
    }
}