using MediatR;
using Microsoft.EntityFrameworkCore;
using VerticalSliceDance.Infrastructure;

namespace VerticalSliceDance.Features.Instructors.TransferToStudio
{
    public class TransferToStudioCommandHandler : IRequestHandler<TransferToStudioCommand, string>
    {
        AppDbContext _context;

        public TransferToStudioCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(TransferToStudioCommand request, CancellationToken cancellationToken)
        {
            var instructor = await _context.Instructors.FirstOrDefaultAsync(i => i.Id == request.InstructorId,cancellationToken);

            if (instructor == null)
            {
                return $"Instructor with ID {request.InstructorId} not found.";
            }

            instructor.StudioId = request.StudioId;

            await _context.SaveChangesAsync(cancellationToken);

            return $"Instructor {instructor.FirstName} {instructor.LastName} has been transferred to studio with ID {request.StudioId}.";

        }
    }
}
