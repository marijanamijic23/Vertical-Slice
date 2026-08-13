using MediatR;
using VerticalSliceDance.Features.Instructors.TransferToStudio;

namespace VerticalSliceDance.Features.Instructors.TransferToStudio
{
    public static class TransferToStudioEndpoint
    {
        public static void MapTransferToStudioEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapPut("/instructors/transfer", async (TransferToStudioCommand command, ISender mediator,CancellationToken ct) =>
            {
                var result = await mediator.Send(command,ct);
                return Results.Ok(result);
            })
            .WithName("TransferToStudio")
            .WithTags("Instructors");
        }
    }
}
