using System.Threading.Tasks;
using Matrix42Merger.Models;

namespace Matrix42Merger.Repositories
{
    public interface ISourcesRepository
    {
        Task Add(Source source);
    }
}