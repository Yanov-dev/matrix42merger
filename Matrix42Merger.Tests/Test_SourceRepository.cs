using System.Linq;
using Matrix42merger.Domain;
using Matrix42Merger.Contexts;
using Matrix42Merger.Repositories.MergedEntities;
using Matrix42Merger.Repositories.Sources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;

namespace Matrix42Merger.Tests
{
    [TestClass]
    public class Test_SourceRepository
    {
        [TestMethod]
        public void Test_Add()
        {
            var container = new UnityContainer();

            container.RegisterType<IMergedEntitiesRepository, MergedEntitiesRepository>();
            container.RegisterType<ISourcesRepository, SourcesRepository>();

            var rep = container.Resolve<ISourcesRepository>();
            var context = container.Resolve<MergeDbContext>();

            var s1 = new Source
            {
                CommonCriteria = "cc",
                Date = "2017.01.01",
                Name = "name1",
                SourceId = "123",
                TargetSource = 1
            };

            var s2 = new Source
            {
                CommonCriteria = "cc",
                Date = "2017.01.01",
                Name = "name1",
                SourceId = "1234",
                TargetSource = 1
            };

            rep.Add(s1).Wait();

            Assert.AreEqual(1, context.Sources.Count());

            rep.Add(s1).Wait();

            Assert.AreEqual(1, context.Sources.Count());

            rep.Add(s2).Wait();

            Assert.AreEqual(2, context.Sources.Count());
        }
    }
}