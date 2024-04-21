namespace MaxonEventManagement.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string PhoneNumber {  get; set; } = string.Empty;
        public string Roles { get; set; } = "User";


    }
}
