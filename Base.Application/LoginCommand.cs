using Base.Infrastructure;
using MediatR;

namespace Base.Application;

public record LoginCommand(LoginDto LoginDto) : IRequest<AuthResponseDto>;

public class LoginCommandHandler : IRequestHandler<LoginCommand, AuthResponseDto>
{
    private readonly IAuthService _authService;

    public LoginCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<AuthResponseDto> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(_authService.Authenticate(request.LoginDto.Email, request.LoginDto.Password));
    }
}