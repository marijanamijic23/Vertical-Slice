using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace VerticalSliceDance.Features.DanceStudios.DeleteStudio;

public static class DeleteStudioEndpoint
{
    public static void MapDeleteStudioEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapDelete("/api/dance-studios/{id:guid}", async (Guid id, [FromServices]ISender mediator, CancellationToken ct) =>
        {
            var result = await mediator.Send(new DeleteStudioCommand(id), ct);
            return Results.Ok(result);
        });
    }
}