using VerticalSliceDance.Domain.Common;
using VerticalSliceDance.Features.DanceStudios.CreateStudio;
using VerticalSliceDance.Features.DanceStudios.DeleteStudio;

namespace VerticalSliceDance.Domain
{
    public class DanceStudio : AggregateRoot
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        public DanceStudio(string name, string address)
        {
            if(string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name is required.", nameof(name));
            }

            if (string.IsNullOrEmpty(address))
            {
                throw new ArgumentException("Address is required.", nameof(address));
            }

            Name = name;
            Address = address;

            AddDomainEvent(new CreateStudioDomainEvents(Id, Name));
        }

        public void DeleteStudio()
        {
            AddDomainEvent(new DeleteStudioDomainEvent(Id, Name));
        }
        public DanceStudio() { }
    }
}
