using System.Threading.Tasks;
using System.Web.Http;
using Matrix42Merger.Dto;
using Matrix42Merger.Services.AuthService;
using Unity.Attributes;

namespace Matrix42Merger.Controllers
{
    [Route("api/source")]
    public class SourceController : ApiController
    {
        [Dependency]
        public IAuthService AuthService { get; set; }

        [HttpPost]
        public async Task Post(SourceDto sourceDto)
        {
        }
    }
}