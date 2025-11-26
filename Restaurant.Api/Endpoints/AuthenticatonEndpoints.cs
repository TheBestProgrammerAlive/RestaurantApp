using MediatR;

namespace Restaurant.Api.Endpoints;

public static class AuthenticatonEndpoints
{

    public static void MapAuthenticationEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/authenticate");
        
        group.MapPost("/", LoginHandler);
    }

    private static Task LoginHandler(IMediator mediator)
    {
        throw new NotImplementedException();
    }
}