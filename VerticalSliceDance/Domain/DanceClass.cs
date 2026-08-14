using Microsoft.EntityFrameworkCore.Query.Internal;
using VerticalSliceDance.Domain.Common;
using VerticalSliceDance.Features.DanceClasses.CreateClass;
using VerticalSliceDance.Features.DanceClasses.DeleteClass;

namespace VerticalSliceDance.Domain
{
    public class DanceClass : AggregateRoot
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public Guid InstructorId { get; set; }
        public Instructor Instructor { get; set; } = null!;

        public ClassSchedule Schedule { get; set; } = null!;

        public DanceClass(string title, Guid instructorId, ClassSchedule schedule)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title is required.", nameof(title));

            if (instructorId == Guid.Empty)
                throw new ArgumentException("InstructorId is required.", nameof(instructorId));

            if (schedule is null)
                throw new ArgumentNullException(nameof(schedule));

            if (schedule.EndTime <= schedule.StartTime)
                throw new ArgumentException("EndTime must be after StartTime.", nameof(schedule));

            Title = title;
            InstructorId = instructorId;
            Schedule = schedule;

            AddDomainEvent(new CreateDanceClassDomainEvent(Id, Title));
        }

        public void Delete()
        {
            AddDomainEvent(new DeleteDanceClassDomainEvent(Id, Title));
        }

        private DanceClass() { }
    }
}
