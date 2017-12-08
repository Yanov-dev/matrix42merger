using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using Matrix42merger.Domain;
using Matrix42Merger.Dto;
using Matrix42Merger.Repositories.Sources;
using Unity.Attributes;

namespace Matrix42Merger.Controllers
{
    [JwtAuthorize]
    [Route("api/source")]
    public class SourceController : ApiController
    {
        [Dependency]
        public ISourcesRepository SourcesRepository { get; set; }

        [HttpPost]
        public MergedEntity Post(SourceDto sourceDto)
        {
            using (var mutex = new Mutex(false, "matrix42"))
            {
                mutex.WaitOne();
                try
                {
                    var source = Mapper.Map<Source>(sourceDto);
                    return SourcesRepository.Add(source).Result;
                }
                finally
                {
                    mutex.ReleaseMutex();
                }
            }
        }

        public async Task<List<MergedEntity>> GetAllData()
        {
            return await SourcesRepository.GetAll().ConfigureAwait(false);
        }
    }
}