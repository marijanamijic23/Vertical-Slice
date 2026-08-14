using FluentValidation;

namespace VerticalSliceDance.Features.Instructors.GetInstructorsByStudio
{
    public class GetInstructorByStudioValidator : AbstractValidator<GetInstructorsByStudioQuery>
    {
        public GetInstructorByStudioValidator()
        {
            RuleFor(x => x.StudioId).NotEmpty();
        }
    }
}
