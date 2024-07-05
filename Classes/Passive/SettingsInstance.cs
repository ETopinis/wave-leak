// Decompiled with JetBrains decompiler
// Type: Wave.Classes.Passive.SettingsInstance
// Assembly: Wave, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 33553988-2CCE-4180-BC86-D1681DD7B18E
// Assembly location: D:\Wave_de\provided\WaveTrial\Wave.exe

using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

#nullable disable
namespace Wave.Classes.Passive
{
  internal class SettingsInstance
  {
    public bool AutoExecute = true;
    public bool MultiInstance;
    public bool SaveTabs;
    public bool TopMost;
    public int EditorRefreshRate = 60;
    public double EditorTextSize = 14.0;
    public bool ShowMinimap;
    public bool ShowInlayHints;
    public string AIUsername = Settings.RandomNames.GetRandomItem();
    public bool UseConversationHistory = true;
    public bool AppendCurrentScript;
    private bool isQueued;

    public async void Save()
    {
      SettingsInstance settingsInstance = this;
      if (settingsInstance.isQueued)
        return;
      settingsInstance.isQueued = true;
      while (settingsInstance.isQueued)
      {
        try
        {
          File.WriteAllText("data/settings.json", JsonConvert.SerializeObject((object) settingsInstance, Formatting.Indented));
          settingsInstance.isQueued = false;
        }
        catch
        {
          await Task.Delay(500);
        }
      }
    }
  }
}
