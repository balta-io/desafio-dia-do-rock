using DesafioDiaDoRock.ApplicationCore;
using DesafioDiaDoRock.ApplicationCore.Interfaces.Integrations;
using DesafioDiaDoRock.ApplicationCore.Interfaces.Services;
using DesafioDiaDoRock.UI;
using DesafioDiaDoRock.UI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IPlacesService, PlacesService>();
builder.Services.AddScoped<IThemeService, ThemeService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<AuthenticationStateProvider, AuthenticationService>();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<IAuthorizationPolicyProvider, DefaultAuthorizationPolicyProvider>();


builder.Services.AddMudServices();

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

Configuration.BackendUrl = builder.HostEnvironment.IsDevelopment() ? Configuration.BackendUrl : "https://api-desafiodiadorock-geh0e9e3gkfpbzgg.eastus-01.azurewebsites.net";

builder.Services.AddHttpClient(WebConfiguration.HttpClientName, client => client.BaseAddress = new Uri(Configuration.BackendUrl));



await builder.Build().RunAsync();