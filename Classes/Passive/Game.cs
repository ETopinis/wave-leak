// Decompiled with JetBrains decompiler
// Type: Wave.Classes.Passive.Game
// Assembly: Wave, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 33553988-2CCE-4180-BC86-D1681DD7B18E
// Assembly location: D:\Wave_de\provided\WaveTrial\Wave.exe

#nullable disable
namespace Wave.Classes.Passive
{
  public class Game
  {
    public string gameId;
    public string name;
    public string imageUrl;

    public void Correct()
    {
      if (!this.imageUrl.StartsWith("/images/"))
        return;
      this.imageUrl = "https://scriptblox.com" + this.imageUrl;
    }
  }
}
