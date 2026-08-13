using MediatR;
using Microsoft.EntityFrameworkCore;
using VerticalSliceDance.Infrastructure;

namespace VerticalSliceDance.Features.DanceStudios.GetStudios
{
    public class GetStudiosQueryHandler : IRequestHandler<GetStudiosQuery, List<StudioDTO>>
    {
        AppDbContext _context;

        public GetStudiosQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<StudioDTO>> Handle(GetStudiosQuery request, CancellationToken cancellationToken)
        {
           return await _context.DanceStudios
                .Select(ds => new StudioDTO
                {
                    Name = ds.Name,
                    Address = ds.Address
                })
                .ToListAsync(cancellationToken);
        }
    }
}
