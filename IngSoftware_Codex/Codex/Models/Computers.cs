using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codex.Models
{
    [Table("computers")]
    public class Computers
    {
        [Key]
        [Column("IdComputers")]
        public int IdComputers { get; set; }

        [Required]
        [Column("Brand")]
        [StringLength(50)]
        public string Brand { get; set; }

        [Required]
        [Column("Model")]
        [StringLength(100)]
        public string Model { get; set; }

        [Required]
        [Column("Processor")]
        [StringLength(100)]
        public string Processor { get; set; }

        [Required]
        [Column("Memory")]
        [StringLength(50)]
        public string Memory { get; set; }

        [Required]
        [Column("Storage")]
        [StringLength(50)]
        public string Storage { get; set; }

        [Required]
        [Column("Price")]
        public decimal Price { get; set; }

        // Relación con Favorites
        public ICollection<Favorite> Favorites { get; set; }
    }
}
