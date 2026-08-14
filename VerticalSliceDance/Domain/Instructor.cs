using VerticalSliceDance.Features.Instructors.TransferToStudio;

namespace VerticalSliceDance.Domain
{
    public class Instructor
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public Guid StudioId { get; set; }
        public DanceStudio DanceStudio { get; set; } = null!;

        public Instructor(string firstName, string lastName, Guid studioId)
        {
            if(string.IsNullOrEmpty(firstName))
            {
                throw new ArgumentException("First name cannot be null or empty.");
            }

            if(string.IsNullOrEmpty(lastName))
            {
                throw new ArgumentException("Last name cannot be null or empty.");
            }

            if(studioId == Guid.Empty) 
            {
                throw new ArgumentException("Studio ID cannot be empty.");
            }

            FirstName = firstName;
            LastName = lastName;
            StudioId = studioId;
        }

        public void TransferToStudio(Guid newStudioId)
        {
            if(newStudioId == Guid.Empty) 
            {
                throw new ArgumentException("New studio ID cannot be empty.");
            }

            if(newStudioId == StudioId)
            {
                throw new InvalidOperationException("Instructor is already assigned to this studio.");
            }

            StudioId = newStudioId; 
        }
        public Instructor() { }
    }
}