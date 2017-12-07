using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Matrix42merger.Domain;
using Matrix42Merger.Dbo;
using Matrix42Merger.Models;

namespace Matrix42Merger.Repositories.MergedEntities
{
    public class MergedEntitiesRepository : IMergedEntitiesRepository
    {
        private readonly MergeDbContext _mergeDbContext;

        public MergedEntitiesRepository(MergeDbContext mergeDbContext)
        {
            _mergeDbContext = mergeDbContext;
        }

        public async Task Add(MergedEntity mergedEntity)
        {
            if (mergedEntity == null)
                throw new ArgumentNullException(nameof(mergedEntity));

            await AddOrUpdate(mergedEntity).ConfigureAwait(false);
        }

        public async Task Update(MergedEntity mergedEntity)
        {
            if (mergedEntity == null)
                throw new ArgumentNullException(nameof(mergedEntity));

            await AddOrUpdate(mergedEntity).ConfigureAwait(false);
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
            var dbModel = await _mergeDbContext
                .MergedEntities
                .Where(e => e.CommonCriteria.Equals(commonCreteria))
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);

            if (dbModel == null)
                return null;

            return Mapper.Map<MergedEntity>(dbModel);
        }

        private async Task AddOrUpdate(MergedEntity mergedEntity)
        {
            var dbModel = Mapper.Map<MergedEntityDbModel>(mergedEntity);

            // where is update method?
            _mergeDbContext.MergedEntities.AddOrUpdate(dbModel);
            await _mergeDbContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}