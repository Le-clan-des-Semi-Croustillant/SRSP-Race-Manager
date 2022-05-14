using Microsoft.AspNetCore.SignalR.Client;
using RaceManager.Language;
using RaceManager.Reading;
using Newtonsoft.Json;
using RaceManager.DataProcessing.Files;
using Microsoft.AspNetCore.Components.Forms;

namespace RaceManager.Pages
{
    /// <summary>
    ///  The Boat Types management page.
    /// </summary>
    public partial class BoatTypesManagement
    {
        /// <value> The list of all the boat types. </value
        private List<IBrowserFile> loadedFiles = new();

        /// <value> The file curently selected </value>
        private IBrowserFile? _pSelected = null;

        private static RMLogger _logger = new RMLogger("BoatTypesManagement");
        private HubConnection? _hubConnection;

        private bool _loaded = false;

        private List<BoatType>? _boatTypesList;
        private BoatType? _btSelected;
        //private Polar? _btselected;

        private Dictionary<string, AField> _fields = new();
        private bool _isFormValid = true;
        private string _errorMessage = "";
        private BoatTypeField<string> _polarfield = new();

        /// <summary>
        /// Remove the selected polar on the selected list.
        /// </summary>
        /// <param name="pol"></param>
        /// <returns></returns>
        private async Task RemovePolar(Polar pol)
        {
            if (_btSelected is not null)
            {
                try
                {
                    _btSelected.PolarFileList.Remove(pol);
                    _logger.log(LoggingLevel.DEBUG, "RemovePolar()", $"Polar {pol.Name} removed");
                    SendBoatTypesList(_boatTypesList);

                }
                catch (Exception e)
                {
                    _logger.log(LoggingLevel.ERROR, "RemovePolar()", $"Error while removing polar {pol.Name} : {e.Message}");
                }
            }
            else _logger.log(LoggingLevel.WARN, "RemovePolar()", $"Trying to remove {pol.Name} but no boat type was selected.");
        }

        /// <summary>
        /// Load basic informations of the file provided by user
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private async Task LoadFiles(InputFileChangeEventArgs e)
        {
            try
            {
                IBrowserFile file = e.File;

                if (file is not null)
                {
                    _pSelected = file;



                    StateHasChanged();
                    _errorMessage = "";
                }

                _logger.log(LoggingLevel.DEBUG, "LoadFiles()", $"{e.File} files loaded");
            }
            catch (Exception ex)
            {
                _errorMessage = ex.Message;
                _pSelected = null;
                _logger.log(LoggingLevel.WARN, "LoadFiles()", $"Error while loading file : {ex.Message}");
            }
        }


        /// <summary>
        /// Add the selected polar to the selected boat type by loading the file into the memory.
        /// </summary>
        /// <returns></returns>
        private async Task AddPolarFile()
        {
            if (_polarfield.StoreValue())
            {
                if (_pSelected is not null && _btSelected is not null)
                {

                    try
                    {
                        Polar pol = new Polar() { Name = _polarfield.Value };
                        MemoryStream ms = new MemoryStream();
                        await _pSelected.OpenReadStream().CopyToAsync(ms);

                        string content = System.Text.Encoding.UTF8.GetString(ms.ToArray());
                        pol.File = FileManageData.CreateFilePolaire(pol.Name, pol.ID, content);

                        _btSelected.PolarFileList.Add(pol);
                        _pSelected = null;
                        StateHasChanged();
                        _logger.log(LoggingLevel.DEBUG, "AddPolarFile()", $"Polar added");
                        _btSelected.PolarFileList.Sort();
                        SendBoatTypesList(_boatTypesList);

                    }
                    catch (Exception ex)
                    {
                        _logger.log(LoggingLevel.ERROR, "AddPolarFile()", ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Add a new boat type
        /// </summary>
        private void BoatTypeSelect(BoatType bt)
        {

            _logger.log(LoggingLevel.DEBUG, "BoatTypeSelect()", $"User select {bt.Name}");
            _btSelected = bt;
            _fields[Locales.Name].FieldContent = _btSelected.Name;
            _fields[Locales.HullLength].FieldContent = _btSelected.HullLength.ToString();
            _fields[Locales.OverallLength].FieldContent = _btSelected.OverallLength.ToString();
            _fields[Locales.HullWidth].FieldContent = _btSelected.HullWidth.ToString();
            _fields[Locales.OverallWidth].FieldContent = _btSelected.OverallWidth.ToString();
            _fields[Locales.AirDraft].FieldContent = _btSelected.AirDraft.ToString();
            _fields[Locales.Draft].FieldContent = _btSelected.Draft.ToString();
            _fields[Locales.Weight].FieldContent = _btSelected.Weight.ToString();

            _pSelected = null;
            foreach (KeyValuePair<string, AField>
                keyValuePair in _fields)
            {
                keyValuePair.Value.isValid = true;
                keyValuePair.Value.Style = "";
            }
            StateHasChanged();
        }

        /// <summary>
        /// Save the boat type
        ///</summary>
        private void Save()
        {
            _isFormValid = true;
            foreach (KeyValuePair<string, AField>
                keyValuePair in _fields)
            {
                AField afield = keyValuePair.Value;
                afield.StoreValue();
                if (afield.isValid == false)
                    _isFormValid = false;
            }

            if (_isFormValid && _btSelected is not null)
            {
                _btSelected.Name = ((BoatTypeField<string>
                    )_fields[Locales.Name]).Value;
                _btSelected.HullLength = ((BoatTypeField<float>
                    )_fields[Locales.HullLength]).Value;
                _btSelected.OverallLength = ((BoatTypeField<float>
                    )_fields[Locales.OverallLength]).Value;
                _btSelected.HullWidth = ((BoatTypeField<float>
                    )_fields[Locales.HullWidth]).Value;
                _btSelected.OverallWidth = ((BoatTypeField<float>
                    )_fields[Locales.OverallWidth]).Value;
                _btSelected.AirDraft = ((BoatTypeField<float>
                    )_fields[Locales.AirDraft]).Value;
                _btSelected.Draft = ((BoatTypeField<float>
                    )_fields[Locales.Draft]).Value;
                _btSelected.Weight = ((BoatTypeField<float>
                    )_fields[Locales.Weight]).Value;
                _boatTypesList.Sort();
                SendBoatTypesList(_boatTypesList);
            }
            StateHasChanged();
        }

        /// <summary>
        /// Remove the boat type
        /// </summary>
        private void RemoveBoatType(BoatType bt)
        {
            _logger.log(LoggingLevel.DEBUG, "RemoveBoatType()", $"Removing {_boatTypesList.Find(x => x.Equals(bt)).Name} is valid.");
            _boatTypesList.Remove(bt);
            _hubConnection.SendAsync("BoatTypesListRemoved", bt);
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
