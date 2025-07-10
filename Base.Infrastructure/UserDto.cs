namespace Base.Infrastructure;

public partial class AuthService
{
    public class UserDto
    {
        public Guid Id { get; set; } 
        public string UserName { get; set; } 
        public string Email { get; set; }
        public string PasswordHash { get; set; } 
        public DateTime CreatedAt { get; set; } 
        public bool IsActive { get; set; } 
    }
}
