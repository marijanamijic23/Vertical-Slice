using FluentValidation;

namespace VerticalSliceDance.Features.DanceClasses.GetClassDetails
{
    public class GetClassDetailsValidator : AbstractValidator<GetClassDetailsQuery>
    {
        public GetClassDetailsValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
