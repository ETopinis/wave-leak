// Decompiled with JetBrains decompiler
// Type: Wave.Classes.WebSockets.WebSocket
// Assembly: Wave, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 33553988-2CCE-4180-BC86-D1681DD7B18E
// Assembly location: D:\Wave_de\provided\WaveTrial\Wave.exe

using System;
using System.Collections.Generic;
using WebSocketSharp.Server;

#nullable disable
namespace Wave.Classes.WebSockets
{
  internal class WebSocket : IDisposable
  {
    public List<string> Behaviours = new List<string>();

    public int Port { get; }

    public WebSocketServer Server { get; }

    public WebSocket(int port)
    {
      this.Port = port;
      this.Server = new WebSocketServer(string.Format("ws://localhost:{0}", (object) port));
    }

    public void AddBehaviour<T>(string path) where T : WebSocketBehavior, new()
    {
      if (this.Behaviours.Contains(path))
        return;
      this.Behaviours.Add(path);
      this.Server.AddWebSocketService<T>(path);
    }

    public void RemoveBehaviour(string path)
    {
      if (!this.Behaviours.Contains(path))
        return;
      this.Server.RemoveWebSocketService(path);
      this.Behaviours.Remove(path);
    }

    public void Dispose()
    {
      foreach (string behaviour in this.Behaviours)
        this.RemoveBehaviour(behaviour);
      this.Server.Stop();
    }
  }
}
