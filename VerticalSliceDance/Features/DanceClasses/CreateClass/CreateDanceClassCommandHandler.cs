using MediatR;
using VerticalSliceDance.Domain;
using VerticalSliceDance.Features.DanceStudios.CreateStudio;
using VerticalSliceDance.Infrastructure;

namespace VerticalSliceDance.Features.DanceClasses.CreateClass 
{
    public class CreateDanceClassCommandHandler : IRequestHandler<CreateDanceClassCommand, string>
    {
        private readonly AppDbContext _context;

        public CreateDanceClassCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(CreateDanceClassCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Dto;

            var danceClass = new DanceClass(dto.Title,dto.InstructorId,dto.ClassSchedule);

            _context.DanceClasses.Add(danceClass);
            await _context.SaveChangesAsync(cancellationToken);

            return $"Dance class {danceClass.Title} has been added.";
    }
    }
}
