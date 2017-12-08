using System.Linq;
using System.Web.Http;
using System.Web.Http.Controllers;
using Matrix42Merger.Services.AuthService;
using Unity;

namespace Matrix42Merger
{
    public class JwtAuthorize : AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            try
            {
                var authService = UnityConfig.Container.Resolve<IAuthService>();
                var token = actionContext.Request.Headers.GetValues("token").First();

                return authService.IsTokenValid(token);
            }
            catch
            {
                return false;
            }
        }
    }
}