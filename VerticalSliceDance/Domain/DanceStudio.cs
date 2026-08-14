using VerticalSliceDance.Domain.Common;
using VerticalSliceDance.Features.DanceStudios.CreateStudio;

namespace VerticalSliceDance.Domain
{
    public class DanceStudio
    {
        public readonly List<IDomainEvent> _domainEvents = new();
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();
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

            _domainEvents.Add(new CreateStudioDomainEvents(Id, Name));
        }

        public void ClearDomainEvents() => _domainEvents.Clear();
        public DanceStudio() { }
    }
}
