using System.Web.Http;

namespace Matrix42Merger.Controllers
{
    [Route("api/account")]
    public class AccountController : ApiController
    {
        [HttpPost]
        public string Login()
        {
            return "OK";
        }
    }
}