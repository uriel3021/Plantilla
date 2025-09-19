using FSH.Starter.Blazor.Client;
using FSH.Starter.Blazor.Infrastructure;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Logging;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Logging.SetMinimumLevel(LogLevel.Debug);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
// Autenticación Azure AD (MSAL) primero
builder.Services.AddMsalAuthentication(options =>
{
    // Configuración se toma directamente de appsettings (AzureAd section)
    builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);
    options.ProviderOptions.LoginMode = "redirect"; // Authorization Code + PKCE
    // Persistencia tokens
    options.ProviderOptions.Cache.CacheLocation = "localStorage";
    options.ProviderOptions.Cache.StoreAuthStateInCookie = false;
    // Scopes openid/profile ya son implícitos en flujo OIDC estándar, no se fuerzan manualmente.
});

// Resto de servicios del cliente después de MSAL
builder.Services.AddClientServices(builder.Configuration);


await builder.Build().RunAsync();
