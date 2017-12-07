using System;
using System.Threading.Tasks;
using Matrix42Merger.Models;

namespace Matrix42Merger.Repositories
{
    public interface ISourcesRepository
    {
        Task Add(Source sourceDbModel);

        Task Update(Source sourceDbModel);

        Task Delete(Source sourceDbModel);
    }
}