using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Matrix42Merger.Contexts;
using Matrix42Merger.Dbo;
using Matrix42Merger.Tests.Internal;
using Moq;

namespace Matrix42Merger.Tests
{
    public class MockEngine
    {
        private readonly Mock<MergeDbContext> _mock;

        public MockEngine(List<SourceDbModel> sourceList = null, List<MergedEntityDbModel> mergedEntityList = null)
        {
            if (sourceList == null)
                sourceList = new List<SourceDbModel>();

            if (mergedEntityList == null)
                mergedEntityList = new List<MergedEntityDbModel>();

            SourcesDbSet = InitDbSet(sourceList.AsQueryable());
            MergedEntitiesDbSet = InitDbSet(mergedEntityList.AsQueryable());

            _mock = new Mock<MergeDbContext>();
            _mock.Setup(c => c.Sources).Returns(SourcesDbSet.Object);
            _mock.Setup(c => c.MergedEntities).Returns(MergedEntitiesDbSet.Object);
        }

        public MergeDbContext Context => _mock.Object;

        public Mock<DbSet<SourceDbModel>> SourcesDbSet { get; }

        public Mock<DbSet<MergedEntityDbModel>> MergedEntitiesDbSet { get; }

        private Mock<DbSet<T>> InitDbSet<T>(IQueryable<T> data) where T : class
        {
            var dbset = new Mock<DbSet<T>>();
            dbset.As<IDbAsyncEnumerable<T>>()
                .Setup(m => m.GetAsyncEnumerator())
                .Returns(new TestDbAsyncEnumerator<T>(data.GetEnumerator()));

            dbset.As<IQueryable<T>>()
                .Setup(m => m.Provider)
                .Returns(new TestDbAsyncQueryProvider<T>(data.Provider));

            dbset.As<IQueryable<T>>().Setup(m => m.Expression).Returns(data.Expression);
            dbset.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(data.ElementType);
            dbset.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            return dbset;
        }
    }
}