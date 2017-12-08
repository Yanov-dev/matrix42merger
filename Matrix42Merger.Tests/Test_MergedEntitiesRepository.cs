using Matrix42Merger.App_Start;
using Matrix42Merger.Repositories.MergedEntities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Matrix42Merger.Tests
{
    [TestClass]
    public class Test_MergedEntitiesRepository
    {
        //----------------------------------------
        // Engine not suppot AddOrUpdate method
        //----------------------------------------

        //[TestMethod]
        //public void Test_AddOrUpdate()
        //{
        //    MapperConfig.Register();
        //    var mockEngine = new MockEngine();
        //    var repository = new MergedEntitiesRepository(mockEngine.Context);

        //    var entity = new MergedEntity
        //    {
        //        CommonCriteria = "cc",
        //        Date = "2017.01.01",
        //        Name = "name1",
        //        MergedTargetSource = 2
        //    };

        //    repository.AddOrUpdate(entity).Wait();

        //    mockEngine.SourcesDbSet.Verify(m => m.Add(It.IsAny<SourceDbModel>()), Times.Once());
        //}

        //[TestMethod]
        //public void Test_GetByCreteria()
        //{
        //    MapperConfig.Register();

        //    var list = new List<MergedEntityDbModel>();

        //    var mockEngine = new MockEngine(mergedEntityList: list);
        //    var repository = new MergedEntitiesRepository(mockEngine.Context);

        //    var entity = new MergedEntity
        //    {
        //        CommonCriteria = "cc",
        //        Date = "2017.01.01",
        //        Name = "name1",
        //        MergedTargetSource = 2
        //    };

        //    repository.AddOrUpdate(entity).Wait();
        //    list.Add(Mapper.Map<MergedEntityDbModel>(entity));

        //    var result = repository.GetByCommonCreteria("cc").Result;
        //    if (result == null)
        //        Assert.Fail("result must be not null");
        //}

        [TestMethod]
        public void Test_AddOrUpdate_Exception()
        {
            MapperConfig.Register();

            var mockEngine = new MockEngine();
            var repository = new MergedEntitiesRepository(mockEngine.Context);

            try
            {
                repository.AddOrUpdate(null).Wait();
                Assert.Fail("must be exception");
            }
            catch
            {
            }
        }
    }
}