using System.Collections.Concurrent;
using HotelReservation.Reservations.ValueObjects;

namespace HotelReservation.Reservations.Models;

/// <summary>
///     Represents the reservation system for hotel rooms.
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global
#pragma warning disable RCS1102
public class Reservation
#pragma warning restore RCS1102
{
    private static readonly ConcurrentDictionary<string, bool> RoomReservations = new();

    public static bool Reserve(Room room)
    {
        return RoomReservations.TryAdd(room.ToString(), true); // Attempt to reserve the room.
    }
}