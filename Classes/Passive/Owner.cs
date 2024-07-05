// Decompiled with JetBrains decompiler
// Type: Wave.Classes.Passive.Owner
// Assembly: Wave, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 33553988-2CCE-4180-BC86-D1681DD7B18E
// Assembly location: D:\Wave_de\provided\WaveTrial\Wave.exe

using System;

#nullable disable
namespace Wave.Classes.Passive
{
  public class Owner
  {
    public string username;
    public string profilePicture;
    public string role;
    public string lastActive;
    public DateTime createdAt;
    public bool verified;
    public bool isBanned;

    public void Correct()
    {
      if (!this.profilePicture.StartsWith("/images/"))
        return;
      this.profilePicture = "https://scriptblox.com" + this.profilePicture;
    }
  }
}
