using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace loginpageusingmvc.Models
{
    public class Skills
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Range(0,100)]
        public int Percentage { get; set; } 
        public string? Category { get; set; }

        public int userid { get; set; }
    }
}
