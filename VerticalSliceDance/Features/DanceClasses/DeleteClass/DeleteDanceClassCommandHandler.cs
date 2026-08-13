using MediatR;
using Microsoft.EntityFrameworkCore;
using VerticalSliceDance.Infrastructure;

namespace VerticalSliceDance.Features.DanceClasses.DeleteClass
{
    public class DeleteDanceClassCommandHandler : IRequestHandler<DeleteDanceClassCommand, string>
    {
        private readonly AppDbContext _context;

        public DeleteDanceClassCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(DeleteDanceClassCommand request, CancellationToken cancellationToken)
        {
            return await _context.DanceClasses
                .Where(ds => ds.Id == request.Id)
                .ExecuteDeleteAsync(cancellationToken) > 0
                ? $"Dance class with Id {request.Id} has been deleted."
                : $"Dance class with Id {request.Id} not found.";
        }
    }
}
