using MediatR;
using Microsoft.EntityFrameworkCore;
using VerticalSliceDance.Infrastructure;

namespace VerticalSliceDance.Features.Instructors.TransferToStudio
{
    public class TransferToStudioCommandHandler : IRequestHandler<TransferToStudioCommand, string>
    {
        private readonly AppDbContext _context;
        private readonly IPublisher _publisher;

        public TransferToStudioCommandHandler(AppDbContext context, IPublisher publisher)
        {
            _context = context;
            _publisher = publisher;
        }

        public async Task<string> Handle(TransferToStudioCommand request, CancellationToken cancellationToken)
        {
            var instructor = await _context.Instructors.FirstOrDefaultAsync(i => i.Id == request.InstructorId,cancellationToken);

            if (instructor == null)
            {
                return $"Instructor with ID {request.InstructorId} not found.";
            }

            instructor.TransferToStudio(request.StudioId);

            await _context.SaveChangesAsync(cancellationToken);

            foreach (var domainEvent in instructor.DomainEvents)
            {
                await _publisher.Publish(domainEvent, cancellationToken);
            }

            instructor.ClearDomainEvents();

            return $"Instructor {instructor.FirstName} {instructor.LastName} has been transferred to studio with ID {request.StudioId}.";

        }
    }
}
