using Base.Domain;
using Base.Infrastructure.DbContexts;

namespace Base.Infrastructure;

public class UserRepository(BaseDbContext context) : IUserRepository
{
    public User? GetById(Guid id) =>
        context.Users.FirstOrDefault(u => u.Id == id);

    public User? GetByEmail(string email) =>
        context.Users.FirstOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

    public IEnumerable<User> GetAll() => context.Users;

    public void Add(User user)
    {
        context.Users.Add(user);
    }

    public void Update(User user)
    {
        var existing = GetById(user.Id);
        if (existing is null) return;

        existing.UserName = user.UserName;
        existing.Email = user.Email;
        existing.PasswordHash = user.PasswordHash;
        existing.IsActive = user.IsActive;
    }

    public void Delete(Guid id)
    {
        var user = GetById(id);
        if (user is not null)
            context.Users.Remove(user);
    }
}