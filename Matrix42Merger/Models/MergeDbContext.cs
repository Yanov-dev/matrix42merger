using System.Data.Entity;

namespace Matrix42Merger.Models
{
    public class MergeDbContext : DbContext
    {
        public DbSet<SourceModel> Sources { get; set; }
    }
}