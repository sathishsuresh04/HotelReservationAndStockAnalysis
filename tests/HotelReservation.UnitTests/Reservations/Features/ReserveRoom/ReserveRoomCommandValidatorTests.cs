using HotelReservation.Reservations.Features.ReserveRoom;

namespace HotelReservation.UnitTests.Reservations.Features.ReserveRoom;

public class ReserveRoomCommandValidatorTests
{
    [Fact]
    public void Validate_ValidCommand_ShouldReturnValidResult()
    {
        // Arrange
        var command = new HotelReservation.Reservations.Features.ReserveRoom.ReserveRoom("ColumbiaSC-Room101");
        var validator = new ReserveRoomCommandValidator();

        // Act
        var result = validator.Validate(command);

        // Assert
        Assert.True(result.IsValid);
    }

    [Fact]
    public void Validate_InvalidCommand_ShouldReturnInvalidResult()
    {
        // Arrange
        var command = new HotelReservation.Reservations.Features.ReserveRoom.ReserveRoom("InvalidRoom");
        var validator = new ReserveRoomCommandValidator();

        // Act
        var result = validator.Validate(command);

        // Assert
        Assert.False(result.IsValid);
    }
}