using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace VerticalSliceDance.Features.DanceClasses.GetClassDetails
{
    public static class GetClassDetailsEndpoint
    {
        public static void MapGetClassDetailsEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapGet("/api/class-details/{id:guid}", async (Guid Id, [FromServices] ISender mediator, CancellationToken ct) =>
            {
                var result = await mediator.Send(new GetClassDetailsQuery(Id), ct);
                return Results.Ok(result);
            });
        }

    }
}
