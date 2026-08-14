using MediatR;
using VerticalSliceDance.Domain;
using VerticalSliceDance.Infrastructure;

namespace VerticalSliceDance.Features.DanceClasses.CreateClass 
{
    public class CreateDanceClassCommandHandler : IRequestHandler<CreateDanceClassCommand, string>
    {
        private readonly AppDbContext _context;
        private readonly IPublisher _publisher;

        public CreateDanceClassCommandHandler(AppDbContext context, IPublisher publisher)
        {
            _context = context;
            _publisher = publisher;
        }

        public async Task<string> Handle(CreateDanceClassCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Dto;

            var danceClass = new DanceClass(dto.Title,dto.InstructorId,dto.ClassSchedule);

            _context.DanceClasses.Add(danceClass);
            await _context.SaveChangesAsync(cancellationToken);

            foreach (var domainEvent in danceClass.DomainEvents)
            {
                await _publisher.Publish(domainEvent, cancellationToken);
            }

            danceClass.ClearDomainEvents();

            return $"Dance class {danceClass.Title} has been added.";
    }
    }
}
