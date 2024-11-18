using System.Net;

namespace HotelReservation.Shared.Exceptions;

// ReSharper disable once ClassNeverInstantiated.Global
#pragma warning disable RCS1194
public class ValidationException : CustomException
#pragma warning restore RCS1194
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ValidationException" /> class with the specified message, inner
    ///     exception, and error messages.
    /// </summary>
    /// <param name="message">The error message that describes the validation error.</param>
    /// <param name="statusCode"></param>
    public ValidationException(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        : base(message)
    {
        StatusCode = statusCode;
    }
}