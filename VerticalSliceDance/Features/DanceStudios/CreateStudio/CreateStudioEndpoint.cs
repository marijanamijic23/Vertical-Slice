using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace VerticalSliceDance.Features.DanceStudios.CreateStudio;

public static class CreateStudioEndpoint
{
    public static void MapCreateStudioEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("/api/dance-studios", async (CreateStudioCommand command, [FromServices]ISender mediator, CancellationToken ct) =>
        {
            var result = await mediator.Send(command, ct);
            return Results.Ok(result);
        });
    }
}