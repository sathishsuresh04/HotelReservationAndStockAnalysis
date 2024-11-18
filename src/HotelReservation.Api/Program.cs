using HotelReservation.Shared;

namespace HotelReservation.Api;

#pragma warning disable RCS1102
public  class Program
#pragma warning restore RCS1102
{
    public static Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.AddReservationManagementServices();
        var app = builder.Build();

        app.UseReservationManagementServices();
        app.MapReservationEndpoints();
        return app.RunAsync();
    }
}