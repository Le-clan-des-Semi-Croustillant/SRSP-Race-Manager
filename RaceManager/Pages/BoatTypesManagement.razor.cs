using Microsoft.AspNetCore.SignalR.Client;
using RaceManager.Language;
using RaceManager.Reading;

namespace RaceManager.Pages
{
    public partial class BoatTypesManagement
    {


        /// <summary>
        /// Remove the boat type
        /// </summary>
        private void Remove(BoatType bt)
        {
            _logger.log(LoggingLevel.DEBUG, "Remove()", $"Removing {_boatTypesList.Find(x => x.Equals(bt)).Name} is valid.");
            _boatTypesList.Remove(bt);
            _btselected = null;
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
            LocaleManager.UpdateCulture();
            _logger.log(LoggingLevel.DEBUG, "OnInitializedAsync()", "Language is " + LocaleManager.CurrentCulture);

            _hubConnection = new HubConnectionBuilder().WithUrl(NavigationManager.ToAbsoluteUri("/boattypeshub")).Build();

            _boatTypesList = new(BoatType.BoatTypesList);
            _boatTypesList.Sort();

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
                await _hubConnection.SendAsync("BoatTypesListSending", _boatTypesList);
            }
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
