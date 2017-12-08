using System.Threading.Tasks;
using System.Web.Http;

namespace Matrix42Merger.Controllers
{
    [Route("api/account")]
    public class AccountController : ApiController
    {
        [HttpPost]
        public async Task<string> Post()
        {
            var username = Request.Headers.GetValues("username");
            var password = Request.Headers.GetValues("password");
            return "OK";
        }
    }
}