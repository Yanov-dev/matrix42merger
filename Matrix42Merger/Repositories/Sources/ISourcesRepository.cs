using System.Threading.Tasks;
using Matrix42merger.Domain;

namespace Matrix42Merger.Repositories.Sources
{
    public interface ISourcesRepository
    {
        Task Add(Source source);

        Task Update(Source source);

        Task Delete(Source source);
    }
}