using System.Globalization;
using System.Threading;
using Race_Manager.locales;

//using System.Pro;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=RaceManager}/{action=Index}/{id?}");

Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
Console.WriteLine(text.Hello);
Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("fr-FR");
Console.WriteLine(text.Hello);

app.Run();
