namespace VerticalSliceDance.Domain
{
    public class DanceStudio
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
                throw new ArgumentException("Name is required.", nameof(address));
            }

            Name = name;
            Address = address;
        }
        public DanceStudio() { }
    }
}
