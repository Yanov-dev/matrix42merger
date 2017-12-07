using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Matrix42merger.Domain;
using Matrix42Merger.Dbo;
using Matrix42Merger.Models;
using Matrix42Merger.Repositories.MergedEntities;
using Unity.Attributes;

namespace Matrix42Merger.Repositories.Sources
{
    public class SourcesRepository : ISourcesRepository
    {
        private readonly MergeDbContext _mergeDbContext;

        public SourcesRepository(MergeDbContext mergeDbContext)
        {
            _mergeDbContext = new MergeDbContext();
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

            var entity = await MergedEntitiesRepository.GetByCommonCreteria(source.CommonCriteria)
                .ConfigureAwait(false);

            var isNew = entity == null;
            if (isNew)
                entity = new MergedEntity();

            Mapper.Map(source, entity);
            entity.AddSource(source);

            if (isNew)
                await MergedEntitiesRepository.Add(entity).ConfigureAwait(false);
            else
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