//using Blazored.LocalStorage;
using RecicladorBlazor.Components;
using RecicladorBlazor.Services;


var builder = WebApplication.CreateBuilder(args);

// Configurar HttpClient com a base da API
builder.Services.AddScoped(sp => new HttpClient
{
    //XYZ --> Seu endereço base da API com / no final
    BaseAddress = new Uri("http://luizfernando.somee.com/RpgApi/")
});
builder.Services.AddScoped<UsuarioService>();
//builder.Services.AddScoped<PersonagemService>();
//builder.Services.AddBlazoredLocalStorage();
//Inicialização da class para uso em outras classes
builder.Services.AddScoped<UsuarioService>();
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
