using Microsoft.EntityFrameworkCore;
using TLM.Books.Application.Interfaces;
using TLM.Books.Domain.Entities;

namespace TLM.Books._Infrastructure;

public class BookDbContext: DbContext, IBookDbContext
{
    public BookDbContext(DbContextOptions<BookDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<Book> Books { get; set; }
    public async Task<int> SaveChangesAsync()
    {
        return await base.SaveChangesAsync();
    }
}