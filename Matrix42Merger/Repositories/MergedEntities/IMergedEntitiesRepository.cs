using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matrix42Merger.Models;

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
