using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Matrix42merger.Domain;

namespace Matrix42Merger.Repositories.Sources
{
    public interface ISourcesRepository
    {
        Task<MergedEntity> Add(Source source);

        Task<MergedEntity> GetById(Guid id);

        Task<MergedEntity> Delete(Source source);

        Task<List<MergedEntity>> GetAll();
    }
}