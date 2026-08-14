using MediatR;
using Microsoft.EntityFrameworkCore;
using VerticalSliceDance.Infrastructure;
using VerticalSliceDance.Domain;

namespace VerticalSliceDance.Features.DanceClasses.DeleteClass
{
    public class DeleteDanceClassCommandHandler : IRequestHandler<DeleteDanceClassCommand, string>
    {
        private readonly AppDbContext _context;
        private readonly IPublisher _publisher;

        public DeleteDanceClassCommandHandler(AppDbContext context, IPublisher publisher)
        {
            _context = context;
            _publisher = publisher;
        }

        public async Task<string> Handle(DeleteDanceClassCommand request, CancellationToken cancellationToken)
        {
            var danceClass = await _context.DanceClasses
                .FirstOrDefaultAsync(ds => ds.Id == request.Id, cancellationToken);

            if (danceClass is null)
            {
                return $"Dance class with Id {request.Id} not found.";
            }

            danceClass.Delete();
            _context.DanceClasses.Remove(danceClass);
            await _context.SaveChangesAsync(cancellationToken);

            foreach (var domainEvent in danceClass.DomainEvents)
            {
                await _publisher.Publish(domainEvent, cancellationToken);
            }

            danceClass.ClearDomainEvents();

            return $"Dance class with Id {request.Id} has been deleted.";
        }
    }
}

