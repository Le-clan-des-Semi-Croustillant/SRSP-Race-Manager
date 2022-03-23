using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.ResponseCompression;
using RaceManager;
using RaceManager.Data;
using RaceManager.Language;
using RaceManager.Pages;
using RaceManager.DataProcessing.Files;
using RaceManager.Lecture;
using Microsoft.AspNetCore.ResponseCompression;

Logger.LogLevel = LoggingLevel.DEBUG;

var builder = WebApplication.CreateBuilder(args);

BoatType.BoatTypesList.Add(new BoatType("A boat")
{
    Name = "Bateau 1",
    IDTypeBateau = 5412,
    LargeurCoque = 4,
    LargeurHorsTout = 1,
    Poids = 4,
    TirantAir = 1,
    TirantEeau = 2,
    LongueurCoque = 5,
    LongueurHorsTout = 1,
    polaire = null
});



// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSignalR();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        new[] { "application/octet-stream" });
});
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.MapHub<BoatTypesListHub>("/boattypeshub");

count c = new count();

//Application["Counter"] = 0; = 999;
//LocaleManager.UpdateCulture();
//Console.WriteLine(Locales.Hello);
LocaleManager.CurrentCulture = "fr";
LocaleManager.UpdateCulture();

FileManage.CheckFilesFolderData();


Logger.log(LoggingLevel.INFO, "Initialisation", "This software is currently in " + Locales.CurrentLanguage + ".");




app.Run();




// void Application_Start(object sender, EventArgs e)
//{
//    //this event is execute only once when application start and it stores the server memory until the worker process is restart  
//    Application["user"] = 0;
//}