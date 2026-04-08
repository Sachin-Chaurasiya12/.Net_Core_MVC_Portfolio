using System.ComponentModel.DataAnnotations;

namespace loginpageusingmvc.DTOs
{
    public class SkillCreateDTO
    {
        public string Title { get; set; }
        public int Percentage { get; set; }
        public string? Category { get; set; }
        public int userid { get; set; }
    }
}
