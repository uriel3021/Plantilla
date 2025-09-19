using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using FSH.Framework.Core.Identity.Users.Abstractions;

namespace FSH.Framework.Infrastructure.Identity.Middleware;

public class LocalRolesClaimsMiddleware
{
    private readonly RequestDelegate _next;

    public LocalRolesClaimsMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.User.Identity?.IsAuthenticated == true)
        {
            var userService = context.RequestServices.GetRequiredService<IUserService>();
            var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!string.IsNullOrEmpty(userId))
            {
                var roles = await userService.GetUserRolesAsync(userId, context.RequestAborted);
                var identity = context.User.Identity as ClaimsIdentity;
                if (identity != null && roles != null)
                {
                    foreach (var role in roles)
                    {
                        identity.AddClaim(new Claim(ClaimTypes.Role, role.RoleName));
                    }
                }
            }
        }
        await _next(context);
    }
}
