
using BookApp.Models;
using Microsoft.EntityFrameworkCore;
namespace BookApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}