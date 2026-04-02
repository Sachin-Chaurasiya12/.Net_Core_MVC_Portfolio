namespace loginpageusingmvc.Models
{
    public class RegisterModel
    {
        public Int32 Id { get; set; }

        public required String Name { get; set; }
        public required String UserName { get; set; }
        public required String Password { get; set; }
    }
}
