using System.Web.Http;
using System.Web.Http.Controllers;
using Matrix42Merger.Services.AuthService;
using Unity.Attributes;

namespace Matrix42Merger
{
    public class JwtAuthorize : AuthorizeAttribute
    {
        [Dependency]
        public IAuthService AuthService { get; set; }

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            return true;
            var token = actionContext.Request.Headers.GetValues("token");
        }
    }
}