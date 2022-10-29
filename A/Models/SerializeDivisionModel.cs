using A.Data.Entities;

namespace A.Models
{
    public class SerializeDivisionModelV2
    {
        public string Name { get; set; } = null;
        public Status Status { get; set; }
        public string? ParentName { get; set; } = null;
        public IEnumerable<SerializeDivisionModelV2> Divisions { get; set; } = null;
    }
}

