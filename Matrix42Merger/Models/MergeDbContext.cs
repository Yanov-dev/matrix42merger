using System.Data.Entity;
using Matrix42Merger.Dbo;

namespace Matrix42Merger.Models
{
    public class MergeDbContext : DbContext
    {
        internal DbSet<SourceDbModel> Sources { get; set; }

        internal DbSet<MergedEntityDbModel> MergedEntities { get; set; }
    }
}