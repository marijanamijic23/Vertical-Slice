using MediatR;
using VerticalSliceDance.Domain;
using VerticalSliceDance.Infrastructure;

namespace VerticalSliceDance.Features.Instructors.CreateInstructor
{
    public class CreateInstructorCommandHandler : IRequestHandler<CreateInstructorCommand, string>
    {
        private readonly AppDbContext _context;

        public CreateInstructorCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(CreateInstructorCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Dto;

            var instructor = new Instructor(dto.FirstName, dto.LastName, dto.StudioId);

            _context.Instructors.Add(instructor);
            await _context.SaveChangesAsync(cancellationToken);

            return $"Instructor {instructor.FirstName} {instructor.LastName} has been added.";
        }
    }
}