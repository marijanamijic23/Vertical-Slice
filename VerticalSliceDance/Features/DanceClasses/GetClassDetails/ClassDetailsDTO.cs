using VerticalSliceDance.Domain;

namespace VerticalSliceDance.Features.DanceClasses.GetClassDetails
{
    public class ClassDetailsDTO
    {
        public string Title { get; set; } = string.Empty;
        public Guid InstructorId { get; set; }
        public ClassSchedule ClassSchedule { get; set; } = null!;
    }
}
