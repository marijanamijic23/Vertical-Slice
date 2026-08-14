using FluentValidation;

namespace VerticalSliceDance.Features.DanceClasses.DeleteClass
{
    public class DeleteDanceClassValidator : AbstractValidator<DeleteDanceClassCommand>
    {
        public DeleteDanceClassValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
