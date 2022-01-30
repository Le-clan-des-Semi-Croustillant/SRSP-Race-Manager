using System.Globalization;
using System.Threading;
using RaceManager.Communication;
using RaceManager.Controllers;
using RaceManager.locales;

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

//Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
//Console.WriteLine(locale.Hello);
AsyncServer.Port = 45678;
AsyncServer.Run();

Console.WriteLine(locale.Hello);
CulturedController.CurrentCulture = "fr-FR";
CulturedController.UpdateCulture();
Console.WriteLine(locale.Hello);
CulturedController.CurrentCulture = "en-US";
CulturedController.UpdateCulture();
Console.WriteLine(locale.Hello);


//AsyncServer.StartListening();

app.Run();
