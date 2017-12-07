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
    [Route("api/source")]
    public class SourceController : ApiController
    {
        [Dependency]
        public ISourcesRepository SourcesRepository { get; set; }

        [HttpPost]
        public async Task Post(SourceDto sourceDto)
        {
            var mutex = new Mutex();

            mutex.WaitOne();

            var source = Mapper.Map<Source>(sourceDto);
            await SourcesRepository.Add(source).ConfigureAwait(false);

            mutex.ReleaseMutex();
        }
    }
}