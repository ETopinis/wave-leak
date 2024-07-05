// Decompiled with JetBrains decompiler
// Type: Wave.Classes.Implementations.BloxstrapSettings
// Assembly: Wave, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 33553988-2CCE-4180-BC86-D1681DD7B18E
// Assembly location: D:\Wave_de\provided\WaveTrial\Wave.exe

using Newtonsoft.Json;
using System;
using System.IO;

#nullable disable
namespace Wave.Classes.Implementations
{
  internal class BloxstrapSettings
  {
    public int BootstrapperStyle;
    public int BootstrapperIcon;
    public string BootstrapperTitle;
    public string BootstrapperIconCustomLocation;
    public int Theme;
    public bool CheckForUpdates;
    public bool CreateDesktopIcon;
    public bool MultiInstanceLaunching;
    public bool OhHeyYouFoundMe;
    public string Channel;
    public int ChannelChangeMode;
    public bool EnableActivityTracking;
    public bool UseDiscordRichPresence;
    public bool HideRPCButtons;
    public bool ShowServerDetails;
    public bool UseOldDeathSound;
    public bool UseOldCharacterSounds;
    public bool UseDisableAppPatch;
    public bool UseOldAvatarBackground;
    public int CursorType;
    public int EmojiType;
    public bool DisableFullscreenOptimizations;

    public void Save()
    {
      File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "/Bloxstrap/Settings.json", JsonConvert.SerializeObject((object) this, Formatting.Indented));
    }
  }
}
