using BarRaider.SdTools;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ResolutionSwitcher.Shared;
using System.Threading.Tasks;

namespace ResolutionSwitcher.StreamDeck
{
    [PluginActionId("be.belgiancoder.resolutionswitcher")]
    public class PluginAction : PluginBase
    {
        private readonly PluginSettings _settings;

        public PluginAction(ISDConnection connection, InitialPayload payload) : base(connection, payload)
        {
            if (payload.Settings == null || payload.Settings.Count == 0)
            {
                _settings = new PluginSettings();
                SaveSettingsAsync();
            }
            else
            {
                _settings = payload.Settings.ToObject<PluginSettings>();
            }
        }

        public override void Dispose()
        {
            Logger.Instance.LogMessage(TracingLevel.INFO, "Destructor called");
        }

        public override async void KeyPressed(KeyPayload payload)
        {
            Logger.Instance.LogMessage(TracingLevel.INFO, "Key Pressed");
            await ExecuteCommand();
        }

        public override void KeyReleased(KeyPayload payload) { }

        public override void OnTick() { }

        public override void ReceivedSettings(ReceivedSettingsPayload payload)
        {
            Tools.AutoPopulateSettings(_settings, payload.Settings);
            SaveSettingsAsync();
        }

        public override void ReceivedGlobalSettings(ReceivedGlobalSettingsPayload payload) { }

        private async void SaveSettingsAsync()
        {
            await Connection.SetSettingsAsync(JObject.FromObject(_settings));
        }

        private async Task ExecuteCommand()
        {
            Logger.Instance.LogMessage(TracingLevel.INFO, "Inside ExecuteCommand");
            Logger.Instance.LogMessage(TracingLevel.INFO, $"{_settings.Heigth} {_settings.Width} {_settings.DPI}");

            var resHelper = new ResolutionHelper();

            if (int.TryParse(_settings.Width, out int width)
                && int.TryParse(_settings.Heigth, out int heigth))
            {
                Logger.Instance.LogMessage(TracingLevel.INFO, "Changing resolution");
                resHelper.ChangeDisplaySettings(width, heigth);
            }

            Logger.Instance.LogMessage(TracingLevel.INFO, "Changing dpi");
            if (int.TryParse(_settings.DPI, out int dpi))
            {
                resHelper.ChangeDpiSettings(dpi);
            }
            else
            {
                resHelper.ChangeDpiSettings(null);
            }

            await Task.CompletedTask;
        }

        private class PluginSettings
        {
            [JsonProperty(PropertyName = "width")]
            public string Width { get; set; }

            [JsonProperty(PropertyName = "heigth")]
            public string Heigth { get; set; }

            [JsonProperty(PropertyName = "dpi")]
            public string DPI { get; set; }
        }
    }
}
