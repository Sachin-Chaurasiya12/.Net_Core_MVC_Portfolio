namespace loginpageusingmvc.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IFormFile ProfileImage { get; set; }
    }
}
