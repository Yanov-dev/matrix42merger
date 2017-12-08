using System.Data.Entity;
using Matrix42Merger.Dbo;

namespace Matrix42Merger.Contexts
{
    public class MergeDbContext : DbContext
    {
        public DbSet<SourceDbModel> Sources { get; set; }

        public DbSet<MergedEntityDbModel> MergedEntities { get; set; }
    }
}