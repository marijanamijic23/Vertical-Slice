using MediatR;

namespace VerticalSliceDance.Features.DanceClasses.DeleteClass
{
    public record DeleteDanceClassCommand(Guid Id) : IRequest<string>;
}

