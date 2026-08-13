namespace VerticalSliceDance.Features.Instructors.CreateInstructor
{
    public class InstructorDTO
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public Guid StudioId { get; set; }

    }
}
