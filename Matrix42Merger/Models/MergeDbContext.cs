using System.Data.Entity;

namespace Matrix42Merger.Models
{
    public class MergeDbContext : DbContext
    {
        public DbSet<Source> Sources { get; set; }

        public DbSet<MergedEntity> MergedEntities { get; set; }
    }
}