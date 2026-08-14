using MediatR;
using VerticalSliceDance.Domain.Common;

namespace VerticalSliceDance.Features.DanceStudios.DeleteStudio
{
    public sealed record DeleteStudioDomainEvent(Guid DanceStudioId, string Name) : IDomainEvent, INotification;
}
