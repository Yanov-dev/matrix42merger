using Matrix42Merger.Dto;
using Matrix42Merger.Models;

namespace Matrix42Merger.Repositories
{
    public class SourcesRepository : ISourcesRepository
    {
        private readonly MergeDbContext _mergeDbContext = new MergeDbContext();

        public void Add(Source source)
        {
            throw new System.NotImplementedException();
        }
    }
}