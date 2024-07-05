// Decompiled with JetBrains decompiler
// Type: Wave.Classes.WebSockets.WebSocketCollection
// Assembly: Wave, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 33553988-2CCE-4180-BC86-D1681DD7B18E
// Assembly location: D:\Wave_de\provided\WaveTrial\Wave.exe

using System.Collections.Generic;

#nullable disable
namespace Wave.Classes.WebSockets
{
  internal class WebSocketCollection
  {
    public static Dictionary<string, WebSocket> Sockets = new Dictionary<string, WebSocket>();

    public static WebSocket AddSocket(string name, int port)
    {
      WebSocket webSocket = new WebSocket(port);
      WebSocketCollection.Sockets.Add(name, webSocket);
      return webSocket;
    }

    public static void RemoveSocket(string name)
    {
      WebSocket socket = WebSocketCollection.Sockets[name];
      if (socket == null)
        return;
      socket.Dispose();
      WebSocketCollection.Sockets.Remove(name);
    }
  }
}
