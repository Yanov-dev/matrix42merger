using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using Matrix42Merger.Models;

namespace Matrix42Merger.Repositories
{
    public class SourcesRepository : ISourcesRepository
    {
        private readonly MergeDbContext _mergeDbContext = new MergeDbContext();

        public async Task Add(Source source)
        {
            var entity = await _mergeDbContext
                .MergedEntities
                .Where(e => e.CommonCriteria.Equals(source.CommonCriteria))
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);

            if (entity == null)
            {
                entity = new MergedEntity();
                entity.Id = Guid.NewGuid();
                entity.Sources = new List<Source>();
            }

            entity.Sources.Add(source);

            _mergeDbContext.MergedEntities.AddOrUpdate(entity);
            _mergeDbContext.Sources.Add(source);

            await _mergeDbContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}