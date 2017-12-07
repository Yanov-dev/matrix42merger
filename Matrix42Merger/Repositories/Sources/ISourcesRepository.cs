using System.Threading.Tasks;
using Matrix42merger.Domain;

namespace Matrix42Merger.Repositories.Sources
{
    public interface ISourcesRepository
    {
        Task Add(Source sourceDbModel);

        Task Update(Source sourceDbModel);

        Task Delete(Source sourceDbModel);
    }
}