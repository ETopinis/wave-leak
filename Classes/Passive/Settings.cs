// Decompiled with JetBrains decompiler
// Type: Wave.Classes.Passive.Settings
// Assembly: Wave, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 33553988-2CCE-4180-BC86-D1681DD7B18E
// Assembly location: D:\Wave_de\provided\WaveTrial\Wave.exe

using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

#nullable disable
namespace Wave.Classes.Passive
{
  internal class Settings
  {
    public static string[] RandomNames = new string[6]
    {
      "Zendaya",
      "Ryan Reynolds",
      "Elon Musk",
      "Queen Liz",
      "Will Smith",
      "Johnny Knoxville"
    };
    private static SettingsInstance instance = (SettingsInstance) null;

    public static SettingsInstance Instance
    {
      get
      {
        if (Settings.instance == null)
        {
          try
          {
            Settings.instance = JsonConvert.DeserializeObject<SettingsInstance>(File.ReadAllText("data/settings.json"));
          }
          catch
          {
            Settings.instance = new SettingsInstance();
          }
          finally
          {
            if (((IEnumerable<string>) Settings.RandomNames).Contains<string>(Settings.instance.AIUsername))
              Settings.instance.AIUsername = Settings.RandomNames.GetRandomItem();
          }
        }
        return Settings.instance;
      }
    }
  }
}
