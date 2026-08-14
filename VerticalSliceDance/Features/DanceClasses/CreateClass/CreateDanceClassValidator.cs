using FluentValidation;

namespace VerticalSliceDance.Features.DanceClasses.CreateClass
{
    public class CreateDanceClassValidator : AbstractValidator<CreateDanceClassCommand>
    {
        public CreateDanceClassValidator()
        {
            RuleFor(x => x.Dto.Title).NotEmpty().MaximumLength(150);
            RuleFor(x => x.Dto.InstructorId).NotEmpty();
            RuleFor(x => x.Dto.ClassSchedule).NotNull();
            RuleFor(x => x.Dto.ClassSchedule.EndTime)
                .GreaterThan(x => x.Dto.ClassSchedule.StartTime)
                .When(x => x.Dto.ClassSchedule is not null)
                .WithMessage("EndTime must be after StartTime.");
        }
    }
}
