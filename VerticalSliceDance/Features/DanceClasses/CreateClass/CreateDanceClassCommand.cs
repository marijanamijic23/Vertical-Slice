using MediatR;

namespace VerticalSliceDance.Features.DanceClasses.CreateClass
{
    public record CreateDanceClassCommand(DanceClassDTO Dto) : IRequest<string>;
}
