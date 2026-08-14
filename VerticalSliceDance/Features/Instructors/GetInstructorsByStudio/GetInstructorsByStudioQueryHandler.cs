using MediatR;
using Microsoft.EntityFrameworkCore;
using VerticalSliceDance.Infrastructure;

namespace VerticalSliceDance.Features.Instructors.GetInstructorsByStudio
{
    public class GetInstructorsByStudioQueryHandler : IRequestHandler<GetInstructorsByStudioQuery, List<InstructorDTO>>
    {
        private readonly AppDbContext _dbContext;

        public GetInstructorsByStudioQueryHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<InstructorDTO>> Handle(GetInstructorsByStudioQuery request, CancellationToken cancellationToken)
        {
            var instructors = await _dbContext.Instructors
                .Where(i => i.StudioId == request.StudioId)
                .Select(i => new InstructorDTO
                {
                    Id = i.Id,
                    FirstName = i.FirstName,
                    LastName = i.LastName 
                })
                .ToListAsync(cancellationToken);

            return instructors;
        }
    }
}
