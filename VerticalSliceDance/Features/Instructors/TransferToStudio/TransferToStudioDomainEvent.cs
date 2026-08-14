using MediatR;
using VerticalSliceDance.Domain.Common;

namespace VerticalSliceDance.Features.Instructors.TransferToStudio
{
    public sealed record TransferToStudioDomainEvent(Guid InstructorId,string FirstName,string LastName,Guid OldStudioId,Guid NewStudioId) : IDomainEvent, INotification;

}
