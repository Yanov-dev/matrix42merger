using Matrix42Merger.Models;

namespace Matrix42Merger.Repositories
{
    public interface ISourcesRepository
    {
        void Add(SourceModel model);
    }
}