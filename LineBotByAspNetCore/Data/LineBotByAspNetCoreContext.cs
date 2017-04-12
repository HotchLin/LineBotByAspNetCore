using Microsoft.EntityFrameworkCore;

namespace LineBotByAspNetCore.Models
{
    public class LineBotByAspNetCoreContext : DbContext
    {
        public LineBotByAspNetCoreContext (DbContextOptions<LineBotByAspNetCoreContext> options)
            : base(options)
        {
        }
        public DbSet<LineBotByAspNetCore.Models.LineKeyword> LineKeyword { get; set; }

        
    }
}
