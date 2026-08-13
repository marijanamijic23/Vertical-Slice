using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace VerticalSliceDance.Features.DanceClasses.DeleteClass
{
    public static class DeleteDanceClassEndpoint
    {
        public static void MapDeleteDanceClassEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapDelete("/api/dance-classes/{id:guid}", async (Guid id, [FromServices] ISender mediator, CancellationToken ct) =>
            {
                var result = await mediator.Send(new DeleteDanceClassCommand(id), ct);
                return Results.Ok(result);
            });
        }
    }
}
