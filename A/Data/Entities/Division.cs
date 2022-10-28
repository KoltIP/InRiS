using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace A.Data.Entities
{
    public class Division
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Name { get; set; } = string.Empty;
        public Status Status { get; set; }
        public string? UpperName { get; set; } = string.Empty;
        public virtual Division? UpperDivision { get; set; }
        public virtual ICollection<Division>? DownDivisions { get; set; }
    }
}
