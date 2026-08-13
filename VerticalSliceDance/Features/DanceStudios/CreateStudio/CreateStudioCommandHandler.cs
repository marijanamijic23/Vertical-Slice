using MediatR;
using VerticalSliceDance.Domain;
using VerticalSliceDance.Infrastructure;

namespace VerticalSliceDance.Features.DanceStudios.CreateStudio;

public class CreateStudioCommandHandler : IRequestHandler<CreateStudioCommand, string>
{
    private readonly AppDbContext _context;

    public CreateStudioCommandHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<string> Handle(CreateStudioCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Dto;

        var studio = new DanceStudio(dto.Name,dto.Address);

        _context.DanceStudios.Add(studio);
        await _context.SaveChangesAsync(cancellationToken);

        return $"Studio {request.Dto.Name} has been created.";
    }
}