// Decompiled with JetBrains decompiler
// Type: Wave.Classes.Implementations.Bloxstrap
// Assembly: Wave, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 33553988-2CCE-4180-BC86-D1681DD7B18E
// Assembly location: D:\Wave_de\provided\WaveTrial\Wave.exe

using Newtonsoft.Json;
using System;
using System.IO;

#nullable disable
namespace Wave.Classes.Implementations
{
  internal class Bloxstrap
  {
    private static BloxstrapSettings instance;

    public static BloxstrapSettings Instance
    {
      get
      {
        if (Bloxstrap.instance == null)
        {
          try
          {
            Bloxstrap.instance = JsonConvert.DeserializeObject<BloxstrapSettings>(File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "/Bloxstrap/Settings.json"));
          }
          catch
          {
            Bloxstrap.instance = new BloxstrapSettings();
          }
        }
        return Bloxstrap.instance;
      }
    }
  }
}
