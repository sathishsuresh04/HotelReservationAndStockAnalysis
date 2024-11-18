
using FluentValidation;
using FluentValidation.Results;
using HotelReservation.Reservations.Features.ReserveRoom;
using NSubstitute;
using ValidationException = HotelReservation.Shared.Exceptions.ValidationException;

namespace HotelReservation.UnitTests.Reservations.Features.ReserveRoom;
public class ReserveRoomHandlerTests
{
    [Fact]
    public async Task Handle_ValidRoom_ShouldReserveRoom()
    {
        // Arrange
        var command = new HotelReservation.Reservations.Features.ReserveRoom.ReserveRoom("ColumbiaSC-Room101");
        var validator = Substitute.For<IValidator<HotelReservation.Reservations.Features.ReserveRoom.ReserveRoom>>();
        validator.ValidateAsync(command, CancellationToken.None).Returns(new ValidationResult());
        var handler = new ReserveRoomHandler(validator);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public async Task Handle_InvalidRoom_ShouldThrowValidationException()
    {
        // Arrange
        var command = new HotelReservation.Reservations.Features.ReserveRoom.ReserveRoom("InvalidRoom");
        var validationFailure = new ValidationFailure("RoomIdentifier", "Invalid room identifier.");
        var validationResult = new ValidationResult(new[] { validationFailure });
        var validator = Substitute.For<IValidator<HotelReservation.Reservations.Features.ReserveRoom.ReserveRoom>>();
        validator.ValidateAsync(command, CancellationToken.None).Returns(validationResult);
        var handler = new ReserveRoomHandler(validator);

        // Act & Assert
        await Assert.ThrowsAsync<ValidationException>(() => handler.Handle(command, CancellationToken.None));
    }

    [Fact]
    public async Task Handle_AlreadyReservedRoom_ShouldReturnFalse()
    {
        // Arrange
        var command = new HotelReservation.Reservations.Features.ReserveRoom.ReserveRoom("ColumbiaSC-Room101");
        var validator = Substitute.For<IValidator<HotelReservation.Reservations.Features.ReserveRoom.ReserveRoom>>();
        validator.ValidateAsync(command, CancellationToken.None).Returns(new ValidationResult());
        var handler = new ReserveRoomHandler(validator);
        await handler.Handle(command, CancellationToken.None); // Reserve the room first

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.False(result);
    }
}