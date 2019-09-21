using Microsoft.EntityFrameworkCore;

namespace Stanza.Api.Models
{
    public class StanzaContext : DbContext
    {
        public StanzaContext(DbContextOptions<StanzaContext> options)
            : base(options) { }
        
        public DbSet<Post> Posts { get; set; }
    }
}