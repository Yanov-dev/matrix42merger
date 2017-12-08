using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Matrix42merger.Domain;

namespace Matrix42Merger.Repositories.MergedEntities
{
    public interface IMergedEntitiesRepository
    {
        Task AddOrUpdate(MergedEntity mergedEntity);

        Task<MergedEntity> GetById(Guid id);

        Task<MergedEntity> GetByCommonCreteria(string commonCreteria);

        Task<List<MergedEntity>> GetAll();
    }
}