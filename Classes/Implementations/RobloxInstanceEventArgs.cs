// Decompiled with JetBrains decompiler
// Type: Wave.Classes.Implementations.RobloxInstanceEventArgs
// Assembly: Wave, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 33553988-2CCE-4180-BC86-D1681DD7B18E
// Assembly location: D:\Wave_de\provided\WaveTrial\Wave.exe

using System;

#nullable disable
namespace Wave.Classes.Implementations
{
  internal class RobloxInstanceEventArgs : EventArgs
  {
    public int Id { get; set; }

    public bool AlreadyOpen { get; set; }

    public RobloxInstanceEventArgs(int id, bool alreadyOpen)
    {
      this.Id = id;
      this.AlreadyOpen = alreadyOpen;
    }
  }
}
