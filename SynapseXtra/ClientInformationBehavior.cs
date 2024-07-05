// Decompiled with JetBrains decompiler
// Type: SynapseXtra.ClientInformationBehavior
// Assembly: Wave, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 33553988-2CCE-4180-BC86-D1681DD7B18E
// Assembly location: D:\Wave_de\provided\WaveTrial\Wave.exe

using Newtonsoft.Json;
using System;
using System.Windows;
using Wave.Classes.Implementations;
using WebSocketSharp;
using WebSocketSharp.Server;

#nullable disable
namespace SynapseXtra
{
  public class ClientInformationBehavior : WebSocketBehavior
  {
    protected override void OnMessage(MessageEventArgs e)
    {
      try
      {
        Roblox.GainProcessInformation(JsonConvert.DeserializeObject<ClientInformation>(e.Data));
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.InnerException.Message);
      }
    }
  }
}
