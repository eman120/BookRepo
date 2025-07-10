using Base.Domain;
using Microsoft.EntityFrameworkCore;

namespace Base.Infrastructure.DbContexts;

public class BaseDbContext : DbContext
{
    public BaseDbContext(DbContextOptions<BaseDbContext> options)
        : base(options)
    {
    }
    public DbSet<Book> Books { get; set; }
    public DbSet<User> Users { get; set; }
}