namespace VerticalSliceDance.Domain
{
    public class DanceStudio
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        public DanceStudio(string name, string address)
        {
            Name = name;
            Address = address;
        }

        public DanceStudio() { }
    }
}
