using System;
using System.Threading.Tasks;
using Matrix42merger.Domain;

namespace Matrix42Merger.Repositories.MergedEntities
{
    public interface IMergedEntitiesRepository
    {
        Task Add(MergedEntity mergedEntity);

        Task Update(MergedEntity mergedEntity);

        Task<MergedEntity> GetById(Guid id);

        Task<MergedEntity> GetByCommonCreteria(string commonCreteria);
    }
}