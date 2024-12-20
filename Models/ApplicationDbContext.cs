using Microsoft.EntityFrameworkCore;

namespace Finshark_api.Models
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }

        DbSet<Stock> Stocks { get; set; }
        DbSet<Comment> Comments { get; set; }

    }
}
