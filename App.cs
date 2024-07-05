// Decompiled with JetBrains decompiler
// Type: Wave.App
// Assembly: Wave, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 33553988-2CCE-4180-BC86-D1681DD7B18E
// Assembly location: D:\Wave_de\provided\WaveTrial\Wave.exe

using CefSharp;
using CefSharp.Wpf;
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows;
using Wave.Classes.Implementations;

#nullable disable
namespace Wave
{
  public class App : Application
  {
    private readonly string[] directories = new string[6]
    {
      "autoexec",
      "data",
      "data/tabs",
      "dependencies",
      "scripts",
      "workspace"
    };
    private Process lspProc;

    private void Application_Startup(object sender, StartupEventArgs e)
    {
      if (Process.GetProcessesByName("Wave").Length > 1)
      {
        int num = (int) MessageBox.Show("Wave is already open, please close it.");
        Environment.Exit(0);
      }
      else if (Assembly.GetEntryAssembly().Location.StartsWith(Path.GetTempPath(), StringComparison.OrdinalIgnoreCase))
      {
        int num = (int) MessageBox.Show("Extract Wave before opening it.");
        Environment.Exit(0);
      }
      else if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "/Bloxstrap/Bloxstrap.exe"))
      {
        int num = (int) MessageBox.Show("You must install Bloxstrap to use Wave.");
        Environment.Exit(0);
      }
      else
      {
        if (Bloxstrap.Instance.Channel != "Live")
        {
          Process[] processesByName = Process.GetProcessesByName("RobloxPlayerBeta");
          if (processesByName.Length != 0)
          {
            if (MessageBox.Show("You are on an unsupported Roblox Channel. Close your games so we can correct this?", "!", MessageBoxButton.YesNo) == MessageBoxResult.No)
            {
              Environment.Exit(0);
              return;
            }
            foreach (Process process in processesByName)
              process.Kill();
          }
          Bloxstrap.Instance.Channel = "Live";
          Bloxstrap.Instance.Save();
        }
        foreach (string directory in this.directories)
        {
          if (!Directory.Exists(directory))
            Directory.CreateDirectory(directory);
        }
        CefSettings settings = new CefSettings();
        settings.SetOffScreenRenderingBestPerformanceArgs();
        Cef.Initialize((CefSettingsBase) settings);
        this.lspProc = Process.Start(new ProcessStartInfo(Environment.CurrentDirectory + "/dist/node.exe")
        {
          WorkingDirectory = Environment.CurrentDirectory + "/dist",
          Arguments = "server",
          WindowStyle = ProcessWindowStyle.Hidden,
          CreateNoWindow = true
        });
        new Wave.MainWindow().Show();
      }
    }

    private void Application_Exit(object sender, ExitEventArgs e)
    {
      if (this.lspProc.HasExited)
        return;
      this.lspProc.Kill();
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public void InitializeComponent()
    {
      this.Startup += new StartupEventHandler(this.Application_Startup);
      this.Exit += new ExitEventHandler(this.Application_Exit);
    }

    [STAThread]
    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public static void Main()
    {
      App app = new App();
      app.InitializeComponent();
      app.Run();
    }
  }
}
