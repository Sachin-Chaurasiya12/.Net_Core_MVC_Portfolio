using System.ComponentModel.DataAnnotations;

namespace loginpageusingmvc.DTOs
{
    public class SkillsReadDTO
    {
        public Int32 Id { get; set; }
        public string? Title { get; set; }
        public int Percentage { get; set; }
        public string? Category { get; set; }
    }
}
