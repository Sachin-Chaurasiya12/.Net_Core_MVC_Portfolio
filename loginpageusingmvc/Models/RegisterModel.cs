namespace loginpageusingmvc.Models
{
    public class RegisterModel
    {
        public Int32 Id { get; set; }

        public required string Name { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required DateOnly Dob { get; set; }
        public required string phonenumber { get; set; }
    }
}
