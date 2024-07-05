// Decompiled with JetBrains decompiler
// Type: Wave.Classes.Implementations.RobloxInstance
// Assembly: Wave, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 33553988-2CCE-4180-BC86-D1681DD7B18E
// Assembly location: D:\Wave_de\provided\WaveTrial\Wave.exe

using System;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

#nullable disable
namespace Wave.Classes.Implementations
{
  internal class RobloxInstance
  {
    public string PipeName = "Wave";
    public Process RobloxProcess;
    public int ProcessId;
    public bool IsRunning;

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern bool WaitNamedPipe(string name, int timeout);

    public RobloxInstance(Process robloxProcess, bool awaitInjection = false)
    {
      if (robloxProcess == null || robloxProcess.ProcessName != "RobloxPlayerBeta")
      {
        int num = (int) MessageBox.Show("Attempted to register invalid process");
      }
      else
      {
        this.RobloxProcess = robloxProcess;
        this.ProcessId = robloxProcess.Id;
        this.PipeName = string.Format("Wave{0}", (object) this.ProcessId);
        if (!awaitInjection)
          return;
        this.AwaitInjection();
      }
    }

    public async void AwaitInjection()
    {
      while (!this.IsInjected())
        await Task.Delay(250);
      this.IsRunning = true;
    }

    public bool IsInjected()
    {
      bool flag = false;
      try
      {
        if (RobloxInstance.WaitNamedPipe("\\\\.\\pipe\\" + this.PipeName, 0))
          flag = true;
      }
      catch (Exception ex)
      {
        flag = false;
      }
      return flag;
    }

    public void ExecuteScript(string script)
    {
      if (!this.IsInjected())
        return;
      new Thread((ThreadStart) (() =>
      {
        try
        {
          using (NamedPipeClientStream pipeClientStream = new NamedPipeClientStream(".", this.PipeName, PipeDirection.Out))
          {
            pipeClientStream.Connect();
            byte[] bytes = Encoding.UTF8.GetBytes(script);
            pipeClientStream.Write(bytes, 0, bytes.Length);
            pipeClientStream.Dispose();
          }
        }
        catch (IOException ex)
        {
          int num = (int) MessageBox.Show("Error occured connecting to the pipe.");
        }
        catch (Exception ex)
        {
          int num = (int) MessageBox.Show(ex.Message);
        }
      })).Start();
    }
  }
}
