using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace A.Data.Entities
{
    public class Division
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Name { get; set; } = string.Empty;
        public Status Status { get; set; }
        public string? ParentName { get; set; } = string.Empty;
        public virtual Division? Parent { get; set; }
        public virtual ICollection<Division>? Children { get; set; }
    }
}
