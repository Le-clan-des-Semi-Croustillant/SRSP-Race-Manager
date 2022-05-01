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

/// <summary>
/// Main
/// </summary>

Console.WriteLine("");
RMLogger logger = new("Program");

var builder = WebApplication.CreateBuilder(args);



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

logger.log(LoggingLevel.INFO, "Initialisation", $"Client ID = {builder.Configuration["Auth0:ClientId"]}");
logger.log(LoggingLevel.INFO, "Initialisation", $"Domain = {builder.Configuration["Auth0:Domain"]}");
logger.log(LoggingLevel.INFO, "Initialisation", $"{builder.Configuration.GetFileProvider().GetFileInfo("appsettings.json").PhysicalPath}");

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

