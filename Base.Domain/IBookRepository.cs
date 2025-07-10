namespace Base.Domain;

public interface IBookRepository
{
    Task<Book?> GetByIdAsync(int id);
    Task<List<Book>> GetAllAsync();
    Task AddAsync(Book entity);
    Task UpdateAsync(Book entity);
    Task DeleteAsync(int id);
}