var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration["ShoppingAPIUrl"];

// Add services to the container.
builder.Services.AddHttpClient("ShoppingAPIClient", client =>
{
    client.BaseAddress = new Uri(config); // Shopping.API url     
    //client.BaseAddress = new Uri(Configuration["ShoppingAPIUrl"]);
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();