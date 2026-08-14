using MediatR;
using Microsoft.EntityFrameworkCore;
using VerticalSliceDance.Domain;
using VerticalSliceDance.Infrastructure;

namespace VerticalSliceDance.Features.DanceStudios.DeleteStudio
{
    public class DeleteStudioCommandHandler
        : IRequestHandler<DeleteStudioCommand, string>
    {
        private readonly AppDbContext _context;
        private readonly IPublisher _publisher;

        public DeleteStudioCommandHandler(
            AppDbContext context,
            IPublisher publisher)
        {
            _context = context;
            _publisher = publisher;
        }

        public async Task<string> Handle(DeleteStudioCommand request, CancellationToken cancellationToken)
        {
            var studio = await _context.DanceStudios
                .FirstOrDefaultAsync(
                    ds => ds.Id == request.Id,
                    cancellationToken);

            if (studio is null)
            {
                return $"Studio with Id {request.Id} not found.";
            }

            studio.DeleteStudio();

            _context.DanceStudios.Remove(studio);

            await _context.SaveChangesAsync(cancellationToken);

            foreach (var domainEvent in studio.DomainEvents)
            {
                await _publisher.Publish(
                    domainEvent,
                    cancellationToken);
            }

            studio.ClearDomainEvents();

            return $"Studio with Id {request.Id} has been deleted.";
        }
    }
}
