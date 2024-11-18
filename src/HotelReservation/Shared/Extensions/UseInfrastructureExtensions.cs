using Microsoft.AspNetCore.Builder;

namespace HotelReservation.Shared.Extensions;

public static class UseInfrastructureExtensions
{
    public static  WebApplication UseInfrastructure(this WebApplication app)
    {
        app.UseExceptionHandler();
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseHttpsRedirection();
        return app;
        
    }
}