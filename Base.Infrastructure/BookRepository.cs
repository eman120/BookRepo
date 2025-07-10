using Base.Domain;
using Base.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Base.Application
{
    public class BookRepository(BaseDbContext baseDbContext) : IBookRepository
    {
        public async Task AddAsync(Book entity)
        {
            baseDbContext.Books
                .Add(entity);
            await baseDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var book = await baseDbContext.Books.FindAsync(id);
            if (book is not null)
            {
                baseDbContext.Books.Remove(book);
                await baseDbContext.SaveChangesAsync();
            }
        }

        public Task<List<Book>> GetAllAsync()
            => baseDbContext.Books.ToListAsync();

        public Task<Book?> GetByIdAsync(int id)
            => baseDbContext.Books.FindAsync(id).AsTask();

        public async Task UpdateAsync(Book book)
        {
            baseDbContext.Books.Update(book);
            await baseDbContext.SaveChangesAsync();
        }
    }
}
