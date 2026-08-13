using MediatR;

namespace VerticalSliceDance.Features.Instructors.TransferToStudio
{
    public record TransferToStudioCommand(Guid InstructorId, Guid StudioId) : IRequest<string>;

}