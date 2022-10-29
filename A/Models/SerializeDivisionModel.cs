using A.Data.Entities;

namespace A.Models
{
    public class SerializeDivisionModel
    {
        public string Name { get; set; } = null;
        public Status Status { get; set; }
        public string? ParentName { get; set; } = null;
        public SerializeDivisionModel Divisions { get; set; } = null;
        //public IEnumerable<SerializeDivisionModel> Divisions { get; set; } = null;
    }
}

