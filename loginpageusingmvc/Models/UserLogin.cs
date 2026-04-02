namespace loginpageusingmvc.Models
{
    public class UserLogin
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public required String Username { get; set; }
        public required String Password { get; set; }
    }
}
