using System.Data.Entity;
using Matrix42Merger.Dbo;

namespace Matrix42Merger.Models
{
    public class MergeDbContext : DbContext
    {
        public DbSet<SourceDbModel> Sources { get; set; }

        public DbSet<MergedEntityDbModel> MergedEntities { get; set; }
    }
}