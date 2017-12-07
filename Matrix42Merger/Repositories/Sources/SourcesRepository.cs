using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Matrix42Merger.Dbo;
using Matrix42Merger.Models;
using Matrix42Merger.Repositories.MergedEntities;
using Unity.Attributes;

namespace Matrix42Merger.Repositories
{
    public class SourcesRepository : ISourcesRepository
    {
        private readonly MergeDbContext _mergeDbContext;

        [Dependency]
        public IMergedEntitiesRepository MergedEntitiesRepository { get; set; }

        public SourcesRepository(MergeDbContext mergeDbContext)
        {
            _mergeDbContext = mergeDbContext;
        }

        public async Task Add(Source source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (await GetSource(source.TargetSource, source.SourceId) != null)
                return;

            var entity = await MergedEntitiesRepository.GetByCommonCreteria(source.CommonCriteria).ConfigureAwait(false);

            if (entity == null)
            {
                entity = new MergedEntity();
                await MergedEntitiesRepository.Add(entity).ConfigureAwait(false);
            }

            var sourceDbModel = Mapper.Map<SourceDbModel>(source);
            sourceDbModel.Id = Guid.NewGuid();

            entity.AddSource(source);

            _mergeDbContext.Sources.Add(sourceDbModel);

            await MergedEntitiesRepository.Update(entity).ConfigureAwait(false);

            await _mergeDbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public Task Update(Source sourceDbModel)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Source sourceDbModel)
        {
            throw new NotImplementedException();
        }

        private async Task<SourceDbModel> GetSource(int targetSourceId, string sourceId)
        {
            return await _mergeDbContext.Sources
                .Where(e => e.SourceId.Equals(sourceId) && e.TargetSource == targetSourceId)
                .FirstOrDefaultAsync().ConfigureAwait(false);
        }
    }
}