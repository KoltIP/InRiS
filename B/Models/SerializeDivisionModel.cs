namespace B.Models
{
    public class SerializeDivisionModel
    {
        public string Name { get; set; } = null;
        public string? ParentName { get; set; } = null;
        public List<SerializeDivisionModel> Divisions { get; set; }
    }
}
