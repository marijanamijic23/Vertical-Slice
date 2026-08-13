using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace VerticalSliceDance.Features.Instructors.GetInstructorsByStudio
{
   public static class GetInstructorsByStudioEndpoint
   {
        public static void MapGetInstructorByStudioEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapGet("/api/instructors", async (Guid studioId,[FromServices] ISender mediator, CancellationToken ct) =>
            {
                var result = await mediator.Send(new GetInstructorsByStudioQuery(studioId), ct);
                return Results.Ok(result);
            });
        }

    }
}
