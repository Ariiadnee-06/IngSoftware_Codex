using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codex.Models
{
    [Table("favorites")]
    public class Favorite
    {
        [Key]
        [Column("IdFavorites")]
        public int IdFavorites { get; set; }

        [ForeignKey("Computer")]
        [Column("IdComputers")]
        public int IdComputers { get; set; }

        [ForeignKey("User")]
        [Column("IdUser")]
        public int IdUser { get; set; }

        // Relaciones
        public Computers Computer { get; set; }
        public User User { get; set; }
    }
}
