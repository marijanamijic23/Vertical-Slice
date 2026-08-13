using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace VerticalSliceDance.Features.DanceStudios.GetStudios
{
    public static class GetStudioEndpoint
    {
        public static void MapGetStudiosEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapGet("/api/dance-studios", async ([FromServices]ISender mediator, CancellationToken ct) =>
            {
                var result = await mediator.Send(new GetStudiosQuery(), ct);
                return Results.Ok(result);
            });
        }
    }
}
