//using Microsoft.AspNetCore.Components;
//using Microsoft.AspNetCore.Components.Web;
//using Microsoft.AspNetCore.ResponseCompression;
//using RaceManager.Communication;
//using RaceManager.DataProcessing.Files;
using Microsoft.AspNetCore.ResponseCompression;
using RaceManager;
using RaceManager.Communication;
using RaceManager.Language;
using RaceManager.Pages;
using RaceManager.DataProcessing.Files;
using RaceManager.Reading;
using Newtonsoft.Json;
using static RaceManager.DataProcessing.Files.FileManageData;
using Auth0.AspNetCore.Authentication; 

//using RaceManager.Communication;
//using RaceManager.DataProcessing.Files;
//using static RaceManager.DataProcessing.Files.FileManageData;


Console.WriteLine("");
RMLogger logger = new(LoggingLevel.INFO, "Program");

var builder = WebApplication.CreateBuilder(args);

//BoatType.BoatTypesList.Add(new BoatType()
//{
//    Name = "Bateau-1",
//    HullWidth = 4,
//    OverallWidth = 1,
//    Weight = 4,
//    AirDraft = 1,
//    Draft = 2,
//    HullLength = 5,
//    OverallLength = 1,
//    PolarFileList = new List<Polar>()
//    {
//        new Polar() {
//            ID = 1234567,
//            Name = "Polar 1",
//            File = "TEST POLAR CONTENT",
//        },
//        new Polar()
//        {
//            ID = 1234568,

//            Name = "Polar 2",
//            File = "TEST POLAR CONTENT",

//        },
//        new Polar()
//        {            ID = 1234569,

//            Name = "Polar 3",
//            File = "TEST POLAR CONTENT",
//        }
//    }
//});



// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
//builder.Services.AddSignalR();
builder.Services.AddSignalR().AddNewtonsoftJsonProtocol(opts =>
opts.PayloadSerializerSettings.TypeNameHandling = TypeNameHandling.Auto); ;

builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        new[] { "application/octet-stream" });
});
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Services
    .AddAuth0WebAppAuthentication(options => {
        options.Domain = builder.Configuration["Auth0:Domain"];
        options.ClientId = builder.Configuration["Auth0:ClientId"];
        //options.
    });
//builder.Services.AddOidcAuthentication(options =>
//{
//    builder.Configuration.Bind("Auth0", options.ProviderOptions);
//    options.ProviderOptions.ResponseType = "code";

//}).AddAccountClaimsPrincipalFactory<
//ArrayClaimsPrincipalFactory<RemoteUserAccount>>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<ServerHub>("/serverhub");
    endpoints.MapHub<BoatTypesListHub>("/boattypeshub");

});
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

FileManageData.CheckFilesFolderData();
FileManageData.UpdateAllBoatTypesList();
FileManageData.ReadBoatTypesList();
FileManageData.UpdateJsonData();

logger.log(LoggingLevel.INFO, "Initialisation", "This software is currently in " + Locales.CurrentLanguage + ".");

AsyncServer.Run();

ServerHub serverHub = new ServerHub();
app.Run();

