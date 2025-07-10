using Base.Domain;

namespace Base.Infrastructure;

public class AuthResponseDto : User
{
    public string Token { get; set; }
    public object RefreshToken { get; set; }
    public DateTime ExpiresAt { get; set; }
    public object User { get; set; }
}