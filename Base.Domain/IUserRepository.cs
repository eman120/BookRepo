using Base.Domain;

namespace Base.Domain;

public interface IUserRepository
{
    User? GetById(Guid id);
    User? GetByEmail(string email);
    IEnumerable<User> GetAll();
    void Add(User user);
    void Update(User user);
    void Delete(Guid id);
}