using MediatR;
using VerticalSliceDance.Domain.Common;

namespace VerticalSliceDance.Features.DanceClasses.DeleteClass
{
    public sealed record DeleteDanceClassDomainEvent(Guid DanceClassId, string Title) : IDomainEvent, INotification;
}
