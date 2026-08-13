using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace VerticalSliceDance.Features.Instructors.CreateInstructor
{
    public static class CreateInstructorEndpoint
    {
        public static void MapCreateInstructorEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapPost("/api/instructors", async (
                InstructorDTO dto,
                [FromServices] ISender mediator,
                CancellationToken ct) =>
            {
                var result = await mediator.Send(new CreateInstructorCommand(dto), ct);
                return Results.Ok(result);
            });
        }
    }
}