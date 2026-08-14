using MediatR;
using VerticalSliceDance.Domain.Common;

namespace VerticalSliceDance.Features.DanceStudios.CreateStudio
{
    public sealed record CreateStudioDomainEvents(Guid DanceStudioId, string Name) : IDomainEvent, INotification;

}
