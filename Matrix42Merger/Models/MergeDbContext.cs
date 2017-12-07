using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Matrix42Merger.Models
{
    public class MergeDbContext : DbContext
    {
        public DbSet<SourceModel> Sources { get; set; }
    }
}