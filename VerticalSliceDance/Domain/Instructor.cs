namespace VerticalSliceDance.Domain
{
    public class Instructor
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public Guid StudioId { get; set; }
        public DanceStudiocs DanceStudio { get; set; } = null!;

        public Instructor(string firstName, string lastName, Guid studioId)
        {
            FirstName = firstName;
            LastName = lastName;
            StudioId = studioId;
        }

        public Instructor() { }
    }
}