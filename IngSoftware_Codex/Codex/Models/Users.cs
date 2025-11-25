using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codex.Models
{
    [Table("users")]
    public class User
    {
        [Key]
        [Column("IdUsers")]
        public int IdUsers { get; set; }

        [Required]
        [Column("Username")]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [Column("Password")]
        [StringLength(200)]
        public string Password { get; set; }

        [ForeignKey("TypeUser")]
        [Column("IdType")]
        public int IdType { get; set; }

        // Relaciones
        public TypeUser TypeUser { get; set; }
        public ICollection<Favorite> Favorites { get; set; }

    }
}
