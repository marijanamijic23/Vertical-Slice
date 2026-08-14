using MediatR;
using VerticalSliceDance.Domain;
using VerticalSliceDance.Infrastructure;

namespace VerticalSliceDance.Features.Instructors.CreateInstructor
{
    public class CreateInstructorCommandHandler : IRequestHandler<CreateInstructorCommand, string>
    {
        private readonly AppDbContext _context;
        private readonly IPublisher _publisher;

        public CreateInstructorCommandHandler(AppDbContext context,IPublisher publisher)
        {
            _context = context;
            _publisher = publisher;
        }

        public async Task<string> Handle(CreateInstructorCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Dto;

            var instructor = new Instructor(dto.FirstName, dto.LastName, dto.StudioId);

            _context.Instructors.Add(instructor);
            await _context.SaveChangesAsync(cancellationToken);

            foreach (var domainEvent in instructor.DomainEvents)
            {
                await _publisher.Publish(domainEvent, cancellationToken);
            }

            instructor.ClearDomainEvents();

            return $"Instructor {instructor.FirstName} {instructor.LastName} has been added.";
        }
    }
}