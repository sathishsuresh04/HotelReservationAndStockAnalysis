using System.Net;

namespace HotelReservation.Shared.Exceptions;

#pragma warning disable RCS1194
public class CustomException(
#pragma warning restore RCS1194
    string message,
    HttpStatusCode statusCode = HttpStatusCode.InternalServerError,
    params string[] errors)
    : Exception(message)
{
    public IEnumerable<string> ErrorMessages { get; protected set; } = errors;

    public HttpStatusCode StatusCode { get; protected set; } = statusCode;
}