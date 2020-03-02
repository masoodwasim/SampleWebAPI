using Microsoft.EntityFrameworkCore;
using SampleWebAPI.DBModels;

namespace SampleWebAPI.DBContext
{
    public class SampleDBContext : DbContext
    {
        public SampleDBContext(DbContextOptions<SampleDBContext> options)
           : base(options)
        {
        }
        public DbSet<BookModel> BooksDbSet { get; set; }
      
    }
}
