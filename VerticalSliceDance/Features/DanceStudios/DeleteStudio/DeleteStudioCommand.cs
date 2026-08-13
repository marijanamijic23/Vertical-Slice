using MediatR;

namespace VerticalSliceDance.Features.DanceStudios.DeleteStudio
{
    public record DeleteStudioCommand(Guid Id) : IRequest<string>;
}
