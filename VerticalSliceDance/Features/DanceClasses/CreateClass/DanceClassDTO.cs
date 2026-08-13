using VerticalSliceDance.Domain;

namespace VerticalSliceDance.Features.DanceClasses.CreateClass
{
    public class DanceClassDTO
    {
        public string Title { get; set; } = string.Empty;
        public Guid InstructorId { get; set; } 
        public ClassSchedule ClassSchedule { get; set; } = null!;

    }
}
