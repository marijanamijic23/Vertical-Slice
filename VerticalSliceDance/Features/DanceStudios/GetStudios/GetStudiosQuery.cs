using MediatR;

namespace VerticalSliceDance.Features.DanceStudios.GetStudios
{
    public record GetStudiosQuery() : IRequest<List<StudioDTO>>;
   
}
