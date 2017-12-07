using System.Web.Http;
using Matrix42Merger.Models;
using Matrix42Merger.Repositories;

namespace Matrix42Merger.Controllers
{
    [JwtAuthorize]
    [Route("api/test")]
    public class TestController : ApiController
    {

        public ISourcesRepository SourcesRepository { get; set; }
        
        public TestController()
        {
            
        }

        public string Get()
        {
            return "OK";
        }
    }
}