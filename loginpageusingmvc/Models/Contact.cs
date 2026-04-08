using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace loginpageusingmvc.Models
{
    public class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string email { get; set; }
        public string? subject { get; set; }
        public string? message { get; set; }

        public Int32 userid { get; set; }

    }
}
