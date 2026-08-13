using MediatR;
using Microsoft.EntityFrameworkCore;
using VerticalSliceDance.Infrastructure;

namespace VerticalSliceDance.Features.DanceStudios.DeleteStudio
{
    public class DeleteStudioCommandHandler : IRequestHandler<DeleteStudioCommand, string>
    {
        AppDbContext _context;

        public DeleteStudioCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(DeleteStudioCommand request, CancellationToken cancellationToken)
        {
            return await _context.DanceStudios
                .Where(ds => ds.Id == request.Id)
                .ExecuteDeleteAsync(cancellationToken) > 0
                ? $"Studio with Id {request.Id} has been deleted."
                : $"Studio with Id {request.Id} not found.";
        }
    }
}
