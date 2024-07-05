// Decompiled with JetBrains decompiler
// Type: Wave.Classes.Implementations.DetailedRobloxInstanceEventArgs
// Assembly: Wave, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 33553988-2CCE-4180-BC86-D1681DD7B18E
// Assembly location: D:\Wave_de\provided\WaveTrial\Wave.exe

using System;

#nullable disable
namespace Wave.Classes.Implementations
{
  internal class DetailedRobloxInstanceEventArgs : EventArgs
  {
    public string Username { get; set; }

    public double UserId { get; set; }

    public int ProcessId { get; set; }

    public string JobId { get; set; }
  }
}
