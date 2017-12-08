using System.Data.Entity;
using Matrix42Merger.Dbo;

namespace Matrix42Merger.Contexts
{
    public class MergeDbContext : DbContext
    {
        public virtual DbSet<SourceDbModel> Sources { get; set; }

        public virtual DbSet<MergedEntityDbModel> MergedEntities { get; set; }
    }
}