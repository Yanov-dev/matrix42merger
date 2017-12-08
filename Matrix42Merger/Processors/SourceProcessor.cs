using System;
using System.Threading.Tasks;
using AutoMapper;
using Matrix42merger.Domain;
using Matrix42Merger.Repositories.MergedEntities;
using Matrix42Merger.Repositories.Sources;

namespace Matrix42Merger.Processors
{
    public class SourceProcessor : ISourceProcessor
    {
        private readonly IMergedEntitiesRepository _mergedEntitiesRepository;
        private readonly ISourcesRepository _sourcesRepository;

        public SourceProcessor(ISourcesRepository sourcesRepository, IMergedEntitiesRepository mergedEntitiesRepository)
        {
            _sourcesRepository = sourcesRepository;
            _mergedEntitiesRepository = mergedEntitiesRepository;
        }

        public async Task Add(Source source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            await _sourcesRepository.Add(source).ConfigureAwait(false);

            var entity = await _mergedEntitiesRepository
                             .GetByCommonCreteria(source.CommonCriteria)
                             .ConfigureAwait(false) ?? new MergedEntity();

            Mapper.Map(source, entity);
            entity.AddSource(source);

            await _mergedEntitiesRepository.AddOrUpdate(entity).ConfigureAwait(false);
        }
    }
}