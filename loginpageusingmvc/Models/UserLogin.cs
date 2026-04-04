namespace loginpageusingmvc.Models
{
    public class UserLogin
    {
        public Int32 Id { get; set; }
        public string? Name { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public DateOnly Dob { get; set; }
        public string? phonenumber { get; set; }
        public string? ProfileImagePath { get; set; }
    }
}
