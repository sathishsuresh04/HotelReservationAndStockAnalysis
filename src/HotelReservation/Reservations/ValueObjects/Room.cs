namespace HotelReservation.Reservations.ValueObjects;

public class Room
{
    private Room(string roomIdentifier)
    {
        RoomIdentifier = roomIdentifier;
    }

    public string RoomIdentifier { get; set; }

    public static Room Create(string roomIdentifier)
    {
        // Add validation logic to ensure room identifiers are well-formed.
        if (string.IsNullOrWhiteSpace(roomIdentifier) || !roomIdentifier.Contains('-'))
            throw new ArgumentException("Invalid room identifier. It must be in the format 'HotelName-RoomNumber'.");
        return new Room(roomIdentifier);
    }

    public override string ToString()
    {
        return RoomIdentifier;
    }
}