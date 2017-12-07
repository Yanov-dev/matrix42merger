using System.Web.Http;
using System.Web.Http.Controllers;
using Matrix42Merger.Services.AuthService;

namespace Matrix42Merger
{
    public class JwtAuthorize : AuthorizeAttribute
    {
        public IAuthService AuthService { get; set; }

        public JwtAuthorize()
        {
        }

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            return true;
            var token = actionContext.Request.Headers.GetValues("token");
            
        }
    }
}