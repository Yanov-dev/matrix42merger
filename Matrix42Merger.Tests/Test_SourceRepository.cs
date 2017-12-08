using System.Collections.Generic;
using AutoMapper;
using Matrix42merger.Domain;
using Matrix42Merger.App_Start;
using Matrix42Merger.Dbo;
using Matrix42Merger.Repositories.Sources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Matrix42Merger.Tests
{
    [TestClass]
    public class Test_SourceRepository
    {
        [TestMethod]
        public void Test_Add()
        {
            MapperConfig.Register();

            var sourceList = new List<SourceDbModel>();
            var mockEngine = new MockEngine(sourceList);

            var repository = new SourcesRepository(mockEngine.Context);

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

            repository.Add(s1).Wait();
            sourceList.Add(Mapper.Map<SourceDbModel>(s1));

            mockEngine.SourcesDbSet.Verify(m => m.Add(It.IsAny<SourceDbModel>()), Times.Once());

            repository.Add(s1).Wait();

            mockEngine.SourcesDbSet.Verify(m => m.Add(It.IsAny<SourceDbModel>()), Times.Once());

            repository.Add(s2).Wait();

            mockEngine.SourcesDbSet.Verify(m => m.Add(It.IsAny<SourceDbModel>()), Times.Exactly(2));
        }

        [TestMethod]
        public void Test_Add_Exeption()
        {
            MapperConfig.Register();

            var mockEngine = new MockEngine();

            var repository = new SourcesRepository(mockEngine.Context);

            try
            {
                repository.Add(null).Wait();
                Assert.Fail("must be exception");
            }
            catch
            {
            }
        }

        [TestMethod]
        public void Test_Delete_Exeption()
        {
            MapperConfig.Register();

            var mockEngine = new MockEngine();

            var repository = new SourcesRepository(mockEngine.Context);

            try
            {
                repository.Delete(null).Wait();
                Assert.Fail("must be exception");
            }
            catch
            {
            }
        }

        [TestMethod]
        public void Test_Delete()
        {
            MapperConfig.Register();

            var sourceList = new List<SourceDbModel>();
            var mockEngine = new MockEngine(sourceList);

            var repository = new SourcesRepository(mockEngine.Context);

            var s1 = new Source
            {
                CommonCriteria = "cc",
                Date = "2017.01.01",
                Name = "name1",
                SourceId = "123",
                TargetSource = 1
            };

            repository.Add(s1).Wait();
            sourceList.Add(Mapper.Map<SourceDbModel>(s1));

            mockEngine.SourcesDbSet.Verify(m => m.Add(It.IsAny<SourceDbModel>()), Times.Once());

            repository.Delete(s1).Wait();
            mockEngine.SourcesDbSet.Verify(m => m.Remove(It.IsAny<SourceDbModel>()), Times.Once());
        }
    }
}