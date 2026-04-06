namespace loginpageusingmvc.DTOs
{
    public class UserCreateDto
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public string? Phonenumber { get; set; }

        public DateOnly Dob { get; set; }

        public string? Role { get; set; }
    }
}
