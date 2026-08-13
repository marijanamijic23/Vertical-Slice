namespace VerticalSliceDance.Domain
{
    public class DanceClass
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public Guid InstructorId { get; set; }
        public Instructor Instructor { get; set; } = null!;

        public ClassSchedule Schedule { get; set; } = null!;

        public DanceClass(string title, Guid instructorId, ClassSchedule schedule)
        {
            Title = title;
            InstructorId = instructorId;
            Schedule = schedule;
        }
        public DanceClass() { }
    }
}
