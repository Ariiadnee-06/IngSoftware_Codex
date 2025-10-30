using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codex.Models
{
    [Table("typeuser")]
    public class TypeUser
    {
        [Key]
        [Column("IdType")]
        public int IdType { get; set; }

        [Required]
        [Column("Type_User")]
        [StringLength(50)]
        public string Type_User { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
