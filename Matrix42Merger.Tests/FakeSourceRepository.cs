using System.Collections.Generic;
using System.Threading.Tasks;
using Matrix42merger.Domain;
using Matrix42Merger.Repositories.Sources;

namespace Matrix42Merger.Tests
{
    public class FakeSourceRepository : ISourcesRepository
    {
        private readonly Dictionary<string, Source> _sources;

        public FakeSourceRepository()
        {
            _sources = new Dictionary<string, Source>();
        }

        public async Task Add(Source source)
        {
            _sources[GetLocalId(source)] = source;
        }

        public async Task Delete(Source source)
        {
            _sources.Remove(GetLocalId(source));
        }

        public async Task Update(Source source)
        {
            _sources[GetLocalId(source)] = source;
        }

        private string GetLocalId(Source source)
        {
            return $"{source.TargetSource}-{source.SourceId}";
        }
    }
}