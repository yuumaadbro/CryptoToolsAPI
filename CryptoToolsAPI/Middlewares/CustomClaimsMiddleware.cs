using System.Security.Claims;

namespace CryptoToolsAPI.Middlewares
{
    /// <summary>
    /// CustomClaimsMiddleware
    /// </summary>
    public class CustomClaimsMiddleware
    {
        private readonly RequestDelegate _requestDelegate;

        /// <summary>
        /// CustomClaimsMiddleware constructor
        /// </summary>
        /// <param name="requestDelegate">RequestDelegate</param>
        public CustomClaimsMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        /// <summary>
        /// Adds claims to current user
        /// </summary>
        /// <param name="context">HttpContext</param>
        /// <param name="serviceProvider">ServiceProvider Interface</param>
        /// <returns>_requestDelegate</returns>
        public async Task InvokeAsync(HttpContext context, IServiceProvider serviceProvider)
        {
            if (context.User.Identity.IsAuthenticated)
            {
                var claimsIdentity = context.User.Identity as ClaimsIdentity;
                using (var scope = serviceProvider.CreateScope())
                {
                    var _authorizationService = scope.ServiceProvider.GetService<Services.IAuthorizationService>();
                    if (_authorizationService != null)
                    {
                        var userId = context.User?.Claims.FirstOrDefault(c => c.Type == "userid")?.Value;
                        List<Claim> customClaims = _authorizationService.GetUserClaims(userId);
                        if (customClaims != null)
                        {
                            foreach (var customClaim in customClaims)
                            {
                                claimsIdentity.AddClaims(customClaims);
                            }
                        }
                    }
                }
            }

            await _requestDelegate(context);
        }
    }
}
