using MediatR;
using Microsoft.EntityFrameworkCore;
using VerticalSliceDance.Infrastructure;

namespace VerticalSliceDance.Features.DanceClasses.GetClassDetails
{
    public class GetClassDetailsQueryHandler : IRequestHandler<GetClassDetailsQuery, ClassDetailsDTO?>
    {
        private readonly AppDbContext _context;

        public GetClassDetailsQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ClassDetailsDTO?> Handle(GetClassDetailsQuery request, CancellationToken cancellationToken)
        {
           return await _context.DanceClasses
                .AsNoTracking()
                .Where(dc => dc.Id == request.Id)
                .Select(dc => new ClassDetailsDTO
                {
                    Title = dc.Title,
                    InstructorId = dc.InstructorId,
                    ClassSchedule = dc.Schedule,
                })
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
