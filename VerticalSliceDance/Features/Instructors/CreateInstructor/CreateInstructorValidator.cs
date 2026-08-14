using FluentValidation;

namespace VerticalSliceDance.Features.Instructors.CreateInstructor
{
    public class CreateInstructorValidator : AbstractValidator<CreateInstructorCommand>
    {
        public CreateInstructorValidator()
        {
            RuleFor(x => x.Dto.FirstName)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Dto.LastName)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Dto.StudioId)
                .NotEmpty();
        }
    }
}
