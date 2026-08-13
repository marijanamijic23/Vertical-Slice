using MediatR;

namespace VerticalSliceDance.Features.DanceStudios.CreateStudio
{
    public record CreateStudioCommand(string Name, string Address) : IRequest<string>;

}