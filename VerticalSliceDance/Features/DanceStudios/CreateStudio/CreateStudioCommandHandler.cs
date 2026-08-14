using MediatR;
using VerticalSliceDance.Domain;
using VerticalSliceDance.Infrastructure;

namespace VerticalSliceDance.Features.DanceStudios.CreateStudio;

public class CreateStudioCommandHandler : IRequestHandler<CreateStudioCommand, string>
{
    private readonly AppDbContext _context;
    private readonly IPublisher _publisher;

    public CreateStudioCommandHandler(AppDbContext context,IPublisher publisher)
    {
        _context = context;
        _publisher = publisher;
    }

    public async Task<string> Handle(CreateStudioCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Dto;

        var studio = new DanceStudio(dto.Name,dto.Address);

        _context.DanceStudios.Add(studio);
        await _context.SaveChangesAsync(cancellationToken);

        foreach (var domainEvent in studio.DomainEvents)
        {
            await _publisher.Publish(domainEvent, cancellationToken);
        }

        studio.ClearDomainEvents();

        return $"Studio {request.Dto.Name} has been created.";
    }
}