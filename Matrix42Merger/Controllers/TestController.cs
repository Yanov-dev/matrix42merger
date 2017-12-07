using System.Web.Http;

namespace Matrix42Merger.Controllers
{
    [Route("api/test")]
    [JwtAuthorize]
    public class TestController : ApiController
    {
        public void Get()
        {
        }
    }
}