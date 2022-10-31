using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace B.Data.Entities
{
    public class Division
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Name { get; set; } = string.Empty;
        public string? ParentName { get; set; } = string.Empty;
        public virtual Division? Parent { get; set; }
        public virtual ICollection<Division>? Children { get; set; }
    }
}
