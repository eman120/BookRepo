using Base.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Base.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class UserController(IUserRepository userRepository) : ControllerBase
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
}
