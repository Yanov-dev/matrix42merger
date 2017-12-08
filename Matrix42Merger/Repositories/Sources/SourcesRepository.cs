using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Matrix42merger.Domain;
using Matrix42Merger.Contexts;
using Matrix42Merger.Dbo;
using Matrix42Merger.Repositories.MergedEntities;
using Unity.Attributes;

namespace Matrix42Merger.Repositories.Sources
{
    public class SourcesRepository : ISourcesRepository
    {
        private readonly MergeDbContext _mergeDbContext;

        public SourcesRepository(MergeDbContext mergeDbContext)
        {
            _mergeDbContext = mergeDbContext;
        }

        [Dependency]
        public IMergedEntitiesRepository MergedEntitiesRepository { get; set; }

        public async Task Add(Source source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (await GetSource(source.TargetSource, source.SourceId) != null)
                return;

            var sourceDbModel = Mapper.Map<SourceDbModel>(source);
            sourceDbModel.Id = Guid.NewGuid();
            _mergeDbContext.Sources.Add(sourceDbModel);
            await _mergeDbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task Delete(Source source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            var sourceDbModel = await GetSource(source.TargetSource, source.SourceId).ConfigureAwait(false);
            if (sourceDbModel != null)
            {
                _mergeDbContext.Sources.Remove(sourceDbModel);
                await _mergeDbContext.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        private async Task<SourceDbModel> GetSource(int targetSourceId, string sourceId)
        {
            return await _mergeDbContext.Sources
                .Where(e => e.SourceId.Equals(sourceId) && e.TargetSource == targetSourceId)
                .FirstOrDefaultAsync().ConfigureAwait(false);
        }
    }
}