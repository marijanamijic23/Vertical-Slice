using MediatR;
using VerticalSliceDance.Domain.Common;

namespace VerticalSliceDance.Features.DanceClasses.CreateClass
{
    public sealed record CreateDanceClassDomainEvent(Guid DanceClassId, string Title) : IDomainEvent,INotification;
}
