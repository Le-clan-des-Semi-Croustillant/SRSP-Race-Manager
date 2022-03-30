//using Microsoft.AspNetCore.Components;
//using Microsoft.AspNetCore.Components.Web;
//using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.ResponseCompression;
using RaceManager;
using RaceManager.Communication;
using RaceManager.Data;
using RaceManager.Language;
using RaceManager.Pages;
using RaceManager.DataProcessing.Files;
using RaceManager.Reading;

RMLogger logger = new(LoggingLevel.INFO, "Program");

var builder = WebApplication.CreateBuilder(args);

BoatType.BoatTypesList.Add(new BoatType()
{
    Name = "Bateau 1",
    HullWidth = 4,
    OverallWidth = 1,
    Weight = 4,
    AirDraft = 1,
    Draft= 2,
    HullLength = 5,
    OverallLength = 1,
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

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<ServerHub>("/serverhub");
    endpoints.MapHub<BoatTypesListHub>("/boattypeshub");

});
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");


count c = new count();

LocaleManager.UpdateCulture("en-US");

FileManage.CheckFilesFolderData();


logger.log(LoggingLevel.INFO, "Initialisation", "This software is currently in " + Locales.CurrentLanguage + ".");


ServerHub serverHub = new ServerHub();
serverHub.UpdateStatus();
app.Run();

