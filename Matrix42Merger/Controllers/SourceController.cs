using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Matrix42Merger.Dto;
using Matrix42Merger.Services.AuthService;

namespace Matrix42Merger.Controllers
{
    [Route("api/source")]
    public class SourceController : ApiController
    {
        public IAuthService AuthService { get; set; }

        [HttpPost]
        public async Task Post(SourceDto sourceDto)
        {
            
        }
    }
}
