using System.Net;

namespace HotelReservation.Shared.Exceptions;

// ReSharper disable once ClassNeverInstantiated.Global
#pragma warning disable RCS1194
public class DomainException : CustomException
#pragma warning restore RCS1194
{
    public DomainException(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        : base(message)
    {
        StatusCode = statusCode;
    }
}