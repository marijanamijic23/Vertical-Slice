using FluentValidation;

namespace VerticalSliceDance.Features.Instructors.TransferToStudio
{
    public class TransferToStudioValidator : AbstractValidator<TransferToStudioCommand>
    {
        public TransferToStudioValidator()
        {
            RuleFor(x => x.InstructorId).NotEmpty();
            RuleFor(x => x.StudioId).NotEmpty();
        }
    }
}
