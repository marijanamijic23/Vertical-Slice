using MediatR;

namespace VerticalSliceDance.Features.Instructors.CreateInstructor
{
    public record CreateInstructorCommand(InstructorDTO Dto) : IRequest<string>;

}