using MediatR;
using VerticalSliceDance.Features.DanceClasses.CreateClass;

namespace VerticalSliceDance.Features.DanceClasses.GetClassDetails
{
    public record GetClassDetailsQuery(Guid Id) : IRequest<ClassDetailsDTO?>;
}
