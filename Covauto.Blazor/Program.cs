using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Covauto.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

const string apiUrl = "https://localhost:7221/";
builder.Services.AddScoped(_ => new HttpClient { BaseAddress = new Uri(apiUrl) });

await builder.Build().RunAsync();