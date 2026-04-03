using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MyAppFrontend;
using MyAppFrontend.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Adiciona o serviço de tasks
builder.Services.AddScoped<TaskItemService>();

// HttpClient para chamar a API
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("http://localhost:5134/") // <-- seu backend
});

await builder.Build().RunAsync();