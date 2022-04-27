using Microsoft.AspNetCore.SignalR.Client;
using RaceManager.Language;
using RaceManager.Reading;
using Newtonsoft.Json;
namespace RaceManager.Pages
{
    public partial class BoatTypesManagement
    {


        /// <summary>
        /// Remove the boat type
        /// </summary>
        private void RemoveBoatType(BoatType bt)
        {
            _logger.log(LoggingLevel.DEBUG, "RemoveBoatType()", $"Removing {_boatTypesList.Find(x => x.Equals(bt)).Name} is valid.");
            _boatTypesList.Remove(bt);
            SendBoatTypesList(_boatTypesList);

            _btSelected = null;
        }

        /// <summary>
        ///  Add a new boat type
        /// </summary>
        private void AddNewBoatType()
        {
            _logger.log(LoggingLevel.DEBUG, "AddNewBoatType()", "User clicked on NewBoat");
            _boatTypesList.Add(new BoatType());
        }

        /// <summary>
        ///  Initialize the component
        /// </summary>
        protected override async Task OnInitializedAsync()
        {
            _logger.log(LoggingLevel.DEBUG, "OnInitializedAsync()", "Language is " + LocaleManager.CurrentCulture);

            _hubConnection = new HubConnectionBuilder().WithUrl(navigationManager.ToAbsoluteUri("/boattypeshub")).AddNewtonsoftJsonProtocol(opts =>
       opts.PayloadSerializerSettings.TypeNameHandling = TypeNameHandling.Auto).Build();

            _boatTypesList = new(BoatType.BoatTypesList);
            _boatTypesList.Sort();
            if (_logger.LogLevel == LoggingLevel.DEBUG)
            {
                _logger.log(LoggingLevel.DEBUG, "OnInitializedAsync()", "BoatTypesList is ");

                foreach (var bt in _boatTypesList)
                {
                    _logger.log(LoggingLevel.DEBUG, "OnInitializedAsync()", $"    {bt.ToString()}");
                }
            }
            _polarfield.FieldContent = Locales.NewPolar;
            await _hubConnection.StartAsync();

            _fields.Add(Locales.Name, new BoatTypeField<string>());
            _fields.Add(Locales.HullLength, new BoatTypeField<float>());
            _fields.Add(Locales.OverallLength, new BoatTypeField<float>());
            _fields.Add(Locales.HullWidth, new BoatTypeField<float>());
            _fields.Add(Locales.OverallWidth, new BoatTypeField<float>());
            _fields.Add(Locales.AirDraft, new BoatTypeField<float>());
            _fields.Add(Locales.Draft, new BoatTypeField<float>());
            _fields.Add(Locales.Weight, new BoatTypeField<float>());

            _loaded = true;
        }

        /// <summary>
        ///  Send the message to the server
        /// </summary>
        private async Task SendBoatTypesList(List<BoatType> btl)
        {
            if (_hubConnection is not null)
            {
                _logger.log(LoggingLevel.DEBUG, "SendBoatTypesList()", "Sending BoatTypesList to server");
                BoatType.logBoats(_logger, LoggingLevel.DEBUG);

                await _hubConnection.SendAsync("BoatTypesListSending", _boatTypesList);
            }
            else _logger.log(LoggingLevel.WARN, "SendPort()", "hubConnection is null");
        }

        public bool IsConnected =>
        _hubConnection?.State == HubConnectionState.Connected;

        /// <summary>
        ///  Dispose the component
        /// </summary>
        public async ValueTask DisposeAsync()
        {
            if (_hubConnection is not null)
            {
                await _hubConnection.DisposeAsync();
            }
        }
    }
}
