using MediatR;
using VerticalSliceDance.Domain;
using VerticalSliceDance.Infrastructure;

namespace VerticalSliceDance.Features.DanceStudios.CreateStudio
{
    public class CreateStudioCommandHandler : IRequestHandler<CreateStudioCommand, string>
    {
        private readonly AppDbContext _context;

        public CreateStudioCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(CreateStudioCommand request, CancellationToken cancellationToken)
        {
            _context.DanceStudios.Add(new DanceStudio
            {
                Name = request.Name,
                Address = request.Address
            });

            await _context.SaveChangesAsync(cancellationToken);

            return $"Studio {request.Name} has been created.";
        }
    }
}