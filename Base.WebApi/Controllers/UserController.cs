using Base.Application;
using Base.Domain;
using Base.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Base.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class UserController(IUserRepository userRepository, IAuthService authService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        var users = await Task.Run(() => userRepository.GetAll().ToList());
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(Guid id)
    {
        var user = await Task.Run(() => userRepository.GetById(id));
        if (user == null)
            return NotFound();
        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(User user)
    {
        await Task.Run(() => userRepository.Add(user));
        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(Guid id, User user)
    {
        if (id != user.Id)
            return BadRequest();

        await Task.Run(() => userRepository.Update(user));
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        await Task.Run(() => userRepository.Delete(id));
        return NoContent();
    }
    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterCommand command)
    {
        var result = authService.Register(command.RegisterDto.Username, command.RegisterDto.Email, command.RegisterDto.Password);
        if (!result)
            return BadRequest("Registration failed. Email may already be in use.");
        return Ok("Registration successful.");
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginCommand command)
    {
        try
        {
            var response = authService.Authenticate(command.LoginDto.Email, command.LoginDto.Password);
            return Ok(response);
        }
        catch (UnauthorizedAccessException)
        {
            return Unauthorized("Invalid credentials or inactive user.");
        }
    }
}
