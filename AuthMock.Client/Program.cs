using AuthMock.Client;
using AuthMock.Client.Extensions;
using AuthMock.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<CustomAuthorizationMessageHandler>();
builder.Services.AddAuthentication();
builder.Services.AddHttpClient("BackendClient", client =>
    client.BaseAddress = new Uri(builder.Configuration.GetConnectionString("BackendUrl")))
    .AddHttpMessageHandler<CustomAuthorizationMessageHandler>();

builder.Services.AddScoped<IProjectsService, ProjectsService>();

await builder.Build().RunAsync();