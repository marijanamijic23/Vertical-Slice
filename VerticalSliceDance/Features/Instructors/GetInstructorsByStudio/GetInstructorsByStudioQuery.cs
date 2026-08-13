using MediatR;

namespace VerticalSliceDance.Features.Instructors.GetInstructorsByStudio
{
    public record class GetInstructorsByStudioQuery(Guid StudioId) : IRequest<List<InstructorDTO>>;
}
