using FluentValidation;

namespace VerticalSliceDance.Features.DanceStudios.DeleteStudio
{
    public class DeleteStudioValidator : AbstractValidator<DeleteStudioCommand>
    {
        public DeleteStudioValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
