using MediatR;

namespace VerticalSliceDance.Features.DanceStudios.CreateStudio
{
    public record CreateStudioCommand(StudioDTO Dto) : IRequest<string>;

}