using DataAccess.Entites;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class BooksStoreDbContext : DbContext
    {
        public BooksStoreDbContext(DbContextOptions<BooksStoreDbContext> options):base(options)
        {
        }

        public DbSet<BookEntity> Books { get; set; }
    }
}
