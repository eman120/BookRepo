using Base.Infrastructure;
using MediatR;

namespace Base.Application;

public record RegisterCommand(RegisterDto RegisterDto) : IRequest<bool>;

public class RegisterCommandHandler(IAuthService authService) : IRequestHandler<RegisterCommand, bool>
{
    public  Task<bool> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(authService.Register(request.RegisterDto.Username, request.RegisterDto.Email, request.RegisterDto.Password));
    }
}
