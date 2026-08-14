using MediatR;
using VerticalSliceDance.Domain.Common;

namespace VerticalSliceDance.Features.Instructors.CreateInstructor
{
    public sealed record CreateInstructorDomainEvent(Guid InstructorId, string FirstName,string LastName) : IDomainEvent, INotification;

}
