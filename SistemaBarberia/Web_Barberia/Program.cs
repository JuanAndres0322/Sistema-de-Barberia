using Web_Barberia.Acceso;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient<ApiClient>(cliente =>
{
    var url = builder.Configuration["ApiBaseUrl"] ?? "http://localhost:5024";
    cliente.BaseAddress = new Uri(url.TrimEnd('/') + "/");
    cliente.Timeout = TimeSpan.FromSeconds(30);
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
