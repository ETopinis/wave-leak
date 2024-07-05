// Decompiled with JetBrains decompiler
// Type: Wave.Classes.Implementations.Roblox
// Assembly: Wave, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 33553988-2CCE-4180-BC86-D1681DD7B18E
// Assembly location: D:\Wave_de\provided\WaveTrial\Wave.exe

using SynapseXtra;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;

#nullable disable
namespace Wave.Classes.Implementations
{
  internal class Roblox
  {
    public static List<RobloxInstance> RobloxInstances = new List<RobloxInstance>();
    private static readonly Timer autoAttachTimer = new Timer(2500.0);
    private static readonly Timer deadProcessTimer = new Timer(2500.0);
    private static readonly string communicationInit = new StreamReader(Application.GetResourceStream(new Uri("Assets\\Scripts\\Communicator.lua", UriKind.Relative)).Stream).ReadToEnd();

    public static event EventHandler<RobloxInstanceEventArgs> OnProcessFound;

    public static event EventHandler<RobloxInstanceEventArgs> OnProcessAdded;

    public static event EventHandler<RobloxInstanceEventArgs> OnProcessRemoved;

    public static event EventHandler<DetailedRobloxInstanceEventArgs> OnProcessInformationGained;

    public static void Start()
    {
      foreach (Process robloxProcess in Process.GetProcessesByName("RobloxPlayerBeta"))
      {
        if (new RobloxInstance(robloxProcess).IsInjected())
          Roblox.AddProcess(robloxProcess, true);
      }
      Roblox.autoAttachTimer.Elapsed += (ElapsedEventHandler) (async (sender, e) =>
      {
        foreach (Process robloxProcess in Process.GetProcessesByName("RobloxPlayerBeta"))
        {
          if (!Roblox.IsProcessAdded(robloxProcess))
          {
            Roblox.AddProcess(robloxProcess);
            await Task.Delay(5000);
            Process.Start("Injector.exe", robloxProcess.Id.ToString());
            break;
          }
          robloxProcess = (Process) null;
        }
      });
      Roblox.autoAttachTimer.Start();
      Roblox.deadProcessTimer.Elapsed += (ElapsedEventHandler) ((sender, e) =>
      {
        for (int index = 0; index < Roblox.RobloxInstances.Count; ++index)
        {
          RobloxInstance instance = Roblox.RobloxInstances[index];
          if (instance.RobloxProcess.HasExited || instance.IsRunning && !instance.IsInjected())
            Application.Current.Dispatcher.Invoke((Action) (() => Roblox.RemoveProcess(instance.RobloxProcess)));
        }
      });
      Roblox.deadProcessTimer.Start();
    }

    public static async void AddProcess(Process robloxProcess, bool alreadyExisted = false)
    {
      RobloxInstance robloxInstance = new RobloxInstance(robloxProcess, true);
      Roblox.RobloxInstances.Add(robloxInstance);
      EventHandler<RobloxInstanceEventArgs> onProcessFound = Roblox.OnProcessFound;
      if (onProcessFound != null)
        onProcessFound((object) robloxProcess, new RobloxInstanceEventArgs(robloxProcess.Id, alreadyExisted));
      while (!robloxInstance.IsRunning)
        await Task.Delay(250);
      Roblox.ExecuteSpecific(new int[1]{ robloxProcess.Id }, Roblox.communicationInit);
      EventHandler<RobloxInstanceEventArgs> onProcessAdded = Roblox.OnProcessAdded;
      if (onProcessAdded == null)
      {
        robloxInstance = (RobloxInstance) null;
      }
      else
      {
        onProcessAdded((object) robloxProcess, new RobloxInstanceEventArgs(robloxProcess.Id, alreadyExisted));
        robloxInstance = (RobloxInstance) null;
      }
    }

    public static void RemoveProcess(Process robloxProcess)
    {
      for (int index = 0; index < Roblox.RobloxInstances.Count; ++index)
      {
        RobloxInstance robloxInstance = Roblox.RobloxInstances[index];
        if (robloxInstance.RobloxProcess == robloxProcess)
        {
          Roblox.RobloxInstances.Remove(robloxInstance);
          break;
        }
      }
      EventHandler<RobloxInstanceEventArgs> onProcessRemoved = Roblox.OnProcessRemoved;
      if (onProcessRemoved == null)
        return;
      onProcessRemoved((object) null, new RobloxInstanceEventArgs(robloxProcess.Id, false));
    }

    public static bool IsProcessAdded(Process robloxProcess)
    {
      for (int index = 0; index < Roblox.RobloxInstances.Count; ++index)
      {
        if (Roblox.RobloxInstances[index].RobloxProcess.Id == robloxProcess.Id)
          return true;
      }
      return false;
    }

    public static void ExecuteSpecific(int[] processIds, string script)
    {
      for (int index = 0; index < Roblox.RobloxInstances.Count; ++index)
      {
        RobloxInstance robloxInstance = Roblox.RobloxInstances[index];
        if (((IEnumerable<int>) processIds).Contains<int>(robloxInstance.ProcessId) && robloxInstance.IsInjected())
          robloxInstance.ExecuteScript(script);
      }
    }

    public static void ExecuteAll(string script)
    {
      for (int index = 0; index < Roblox.RobloxInstances.Count; ++index)
      {
        RobloxInstance robloxInstance = Roblox.RobloxInstances[index];
        if (robloxInstance.IsInjected())
          robloxInstance.ExecuteScript(script);
      }
    }

    public static void GainProcessInformation(ClientInformation clientInfo)
    {
      EventHandler<DetailedRobloxInstanceEventArgs> informationGained = Roblox.OnProcessInformationGained;
      if (informationGained == null)
        return;
      informationGained((object) null, new DetailedRobloxInstanceEventArgs()
      {
        Username = clientInfo.Username,
        UserId = clientInfo.UserId,
        ProcessId = clientInfo.ProcessId,
        JobId = clientInfo.JobId
      });
    }
  }
}
