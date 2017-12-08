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

namespace Matrix42Merger.Repositories.MergedEntities
{
    public class MergedEntitiesRepository : IMergedEntitiesRepository
    {
        private readonly MergeDbContext _mergeDbContext;

        public MergedEntitiesRepository(MergeDbContext mergeDbContext)
        {
            _mergeDbContext = mergeDbContext;
        }

        public async Task<MergedEntity> GetById(Guid id)
        {
            var entity = await _mergeDbContext.MergedEntities.FindAsync(id).ConfigureAwait(false);
            if (entity == null)
                return null;

            return Mapper.Map<MergedEntity>(entity);
        }

        public async Task<MergedEntity> GetByCommonCreteria(string commonCreteria)
        {
            if (string.IsNullOrEmpty(commonCreteria))
                throw new ArgumentNullException(nameof(commonCreteria));

            var dbModel = await GetDbModelByCommonCreteria(commonCreteria).ConfigureAwait(false);
            if (dbModel == null)
                return null;

            return Mapper.Map<MergedEntity>(dbModel);
        }

        public async Task<List<MergedEntity>> GetAll()
        {
            var dbModels = await _mergeDbContext.MergedEntities.ToListAsync().ConfigureAwait(false);

            return Mapper.Map<List<MergedEntity>>(dbModels);
        }

        public async Task AddOrUpdate(MergedEntity mergedEntity)
        {
            if (mergedEntity == null)
                throw new ArgumentNullException(nameof(mergedEntity));

            var id = (await GetDbModelByCommonCreteria(mergedEntity.CommonCriteria))?.Id ?? Guid.NewGuid();

            var dbModel = Mapper.Map<MergedEntityDbModel>(mergedEntity);
            dbModel.Id = id;

            // where is update method?
            _mergeDbContext.MergedEntities.AddOrUpdate(dbModel);
            await _mergeDbContext.SaveChangesAsync().ConfigureAwait(false);
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
    }
}