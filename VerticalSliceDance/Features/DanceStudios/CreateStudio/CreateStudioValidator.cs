using FluentValidation;

namespace VerticalSliceDance.Features.DanceStudios.CreateStudio
{
    public class CreateStudioValidator : AbstractValidator<CreateStudioCommand>
    {
        public CreateStudioValidator()
        {
            RuleFor(x => x.Dto.Name)
                .NotEmpty()
                .MaximumLength(150);

            RuleFor(x => x.Dto.Address)
                .NotEmpty();
        }
    }
}
