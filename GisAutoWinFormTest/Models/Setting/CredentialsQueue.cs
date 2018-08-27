using System.Collections.Generic;
using System.Configuration;

namespace GisAutoWinFormTest.Models.Setting
{
    internal class CustomApplicationSettings : ApplicationSettingsBase
    {
        [UserScopedSetting()]
        [SettingsSerializeAs(SettingsSerializeAs.Binary)]
        [DefaultSettingValue("")]
        public Queue<KeyValuePair<string,string>> CredentialsQueue
        {
            get => this["CredentialsQueue"] as Queue<KeyValuePair<string, string>>;
            set => this["CredentialsQueue"] = value;
        }
    }
}
