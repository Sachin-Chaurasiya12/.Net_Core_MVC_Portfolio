namespace loginpageusingmvc.DTOs
{
    public class MessageCreateDTO
    {
        public Int32 id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string? subject { get; set; }
        public string? message { get; set; }
        public int userid { get; set; }
    }
}
