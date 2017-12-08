using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Matrix42merger.Domain;
using Matrix42Merger.Contexts;
using Matrix42Merger.Dbo;

namespace Matrix42Merger.Repositories.Sources
{
    public class SourcesRepository : ISourcesRepository
    {
        private readonly MergeDbContext _mergeDbContext;

        public SourcesRepository(MergeDbContext mergeDbContext)
        {
            _mergeDbContext = mergeDbContext;
        }

        public async Task<MergedEntity> Add(Source source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            // if we added this source, that ship
            var sourceDbModel = await GetSourceDbModel(source).ConfigureAwait(false);
            if (sourceDbModel != null)
                return await GetById(sourceDbModel.MergedEntityDbModelId).ConfigureAwait(false);

            // create new if not exist
            var mergedEntityDbModel = await GetDbModelByCommonCreteria(source.CommonCriteria).ConfigureAwait(false);
            if (mergedEntityDbModel == null)
            {
                mergedEntityDbModel = new MergedEntityDbModel();
                mergedEntityDbModel.Sources = new List<SourceDbModel>();
                mergedEntityDbModel.Id = Guid.NewGuid();
            }

            Mapper.Map(source, mergedEntityDbModel);

            sourceDbModel = Mapper.Map<SourceDbModel>(source);
            sourceDbModel.Id = Guid.NewGuid();

            mergedEntityDbModel.Sources.Add(sourceDbModel);

            var result = Mapper.Map<MergedEntity>(mergedEntityDbModel);
            result.CalculateMergedTargetSource();

            mergedEntityDbModel.MergedTargetSource = result.MergedTargetSource;
            _mergeDbContext.MergedEntities.AddOrUpdate(mergedEntityDbModel);
            await _mergeDbContext.SaveChangesAsync().ConfigureAwait(false);

            return result;
        }

        public async Task<MergedEntity> GetById(Guid id)
        {
            var dbModel = await _mergeDbContext.MergedEntities.FirstOrDefaultAsync(e => e.Id == id)
                .ConfigureAwait(false);
            if (dbModel == null)
                return null;

            return Mapper.Map<MergedEntity>(dbModel);
        }

        public Task<MergedEntity> Delete(Source source)
        {
            throw new NotImplementedException();
        }

        public async Task<List<MergedEntity>> GetAll()
        {
            var list = await _mergeDbContext.MergedEntities.ToListAsync().ConfigureAwait(false);
            return Mapper.Map<List<MergedEntity>>(list);
        }

        private async Task<MergedEntityDbModel> GetDbModelByCommonCreteria(string commonCreteria)
        {
            var res = await _mergeDbContext
                .MergedEntities
                .Where(e => e.CommonCriteria.Equals(commonCreteria))
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);
            return res;
        }

        private async Task<SourceDbModel> GetSourceDbModel(Source source)
        {
            return await _mergeDbContext.Sources
                .Where(e => e.SourceId.Equals(source.SourceId) && e.TargetSource == source.TargetSource)
                .FirstOrDefaultAsync().ConfigureAwait(false);
        }
    }
}