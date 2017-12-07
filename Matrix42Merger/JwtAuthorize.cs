using System.Web.Http;
using System.Web.Http.Controllers;
using Matrix42Merger.Services.AuthService;

namespace Matrix42Merger
{
    public class JwtAuthorize : AuthorizeAttribute
    {
        private readonly IAuthService _authService;

        public JwtAuthorize(IAuthService authService)
        {
            _authService = authService;
        }

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var token = actionContext.Request.Headers.GetValues("token");
            return true;
        }
    }
}