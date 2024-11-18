using HotelReservation.Reservations.ValueObjects;

namespace HotelReservation.UnitTests;

public class RoomTests
{
    [Fact]
    public void Create_ValidRoomIdentifier_ShouldCreateRoom()
    {
        // Arrange
        const string roomIdentifier = "ColumbiaSC-Room101";

        // Act
        var room = Room.Create(roomIdentifier);

        // Assert
        Assert.Equal(roomIdentifier, room.RoomIdentifier);
    }

    [Fact]
    public void Create_InvalidRoomIdentifier_ShouldThrowArgumentException()
    {
        // Arrange
        const string invalidRoomIdentifier = "InvalidRoom";

        // Act & Assert
        Assert.Throws<ArgumentException>(() => Room.Create(invalidRoomIdentifier));
    }
}
