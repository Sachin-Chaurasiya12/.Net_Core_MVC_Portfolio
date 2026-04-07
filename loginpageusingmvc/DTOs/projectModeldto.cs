namespace loginpageusingmvc.DTOs
{
    public class ProjectModeldto
    {
        public Int32 ProjectId { get; set; }
        public Int32 UserId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ImagePath { get; set; }
        public string? GithubUrl { get; set; }
    }
}
