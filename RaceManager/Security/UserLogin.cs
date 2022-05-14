using Microsoft.AspNetCore.SignalR;


namespace RaceManager.Security
{
    /// <summary>
    ///  A SignalR hub for the homemade authentication service.
    /// </summary>
    public class LoginHub : Hub
    {

        private static RMLogger logger = new RMLogger("LoginHub");
        private static IConfiguration Configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
    .Build();
        private static string AdminPassword = getAdminPasswordFromConfig();
        
        private static string getAdminPasswordFromConfig()
        {
            if ( Configuration["Authentication:AdminPassword"] != null)
            {
                logger.log(LoggingLevel.WARN, "getAdminPasswordFromConfig()", $"password is {Configuration["Authentication:AdminPassword"]}");
                return Configuration["Authentication:AdminPassword"];
            }
            else {
                logger.log(LoggingLevel.WARN, "getAdminPasswordFromConfig()", $"No AdminPassword set, using \"password\" instead");
                return "password";
            }
        }

        /// <summary>
        /// Called when a new connection is established with the hub.
        /// </summary>
        /// <returns></returns>
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        /// <summary>
        /// Return to the client if the provided password is correct.
        /// </summary>
        public async Task IsPasswordMatching(string password)
        {
            if (password == AdminPassword)
            {
                logger.log(LoggingLevel.INFO, "passwordMatch()", $"Password match for user {Context.ConnectionId}");
                await Clients.Caller.SendAsync("passwordMatch", true);
                
            }
            else
            {
                logger.log(LoggingLevel.INFO, "passwordMatch()", $"Password mismatch ({password}) for user {Context.ConnectionId}");
                await Clients.Caller.SendAsync("passwordMatch", false);
            }
        }


    }
}
