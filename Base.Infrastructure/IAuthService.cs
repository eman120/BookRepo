namespace Base.Infrastructure;

public interface IAuthService
{
    AuthResponseDto Authenticate(string email, string password);
    bool Register(string userName, string email, string password);
}
