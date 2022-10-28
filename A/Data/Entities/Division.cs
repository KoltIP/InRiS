namespace A.Data.Entities
{
    public class Division
    {
        public string Name { get; set; } = string.Empty;
        public Status Status { get; set; }
        public string UpperName { get; set; }
        public virtual Division UpperDivision { get; set; }
        public virtual ICollection<Division> Divisions { get; set; }
    }
}
