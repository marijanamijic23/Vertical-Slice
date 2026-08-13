using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace VerticalSliceDance.Features.DanceClasses.CreateClass
{
    public static class DanceClassEndpoint
    {
        public static void MapCreateDanceClassEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapPost("/api/dance-classes", async (CreateDanceClassCommand command, [FromServices] ISender mediator, CancellationToken ct) =>
            {
                var result = await mediator.Send(command, ct);
                return Results.Ok(result);
            });
        }
    }
}
