// Decompiled with JetBrains decompiler
// Type: Wave.MainWindow
// Assembly: Wave, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 33553988-2CCE-4180-BC86-D1681DD7B18E
// Assembly location: D:\Wave_de\provided\WaveTrial\Wave.exe

using CefSharp;
using CefSharp.Wpf;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SynapseXtra;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Timers;
using System.Web;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Wave.Classes.Cosmetic;
using Wave.Classes.Implementations;
using Wave.Classes.Passive;
using Wave.Classes.WebSockets;
using Wave.Controls;
using Wave.Controls.AI;
using Wave.Controls.Settings;

#nullable disable
namespace Wave
{
  public partial class MainWindow : Window, IComponentConnector, IStyleConnector
  {
    private readonly string fullscreenPath = "M200-200h80q17 0 28.5 11.5T320-160q0 17-11.5 28.5T280-120H160q-17 0-28.5-11.5T120-160v-120q0-17 11.5-28.5T160-320q17 0 28.5 11.5T200-280v80Zm560 0v-80q0-17 11.5-28.5T800-320q17 0 28.5 11.5T840-280v120q0 17-11.5 28.5T800-120H680q-17 0-28.5-11.5T640-160q0-17 11.5-28.5T680-200h80ZM200-760v80q0 17-11.5 28.5T160-640q-17 0-28.5-11.5T120-680v-120q0-17 11.5-28.5T160-840h120q17 0 28.5 11.5T320-800q0 17-11.5 28.5T280-760h-80Zm560 0h-80q-17 0-28.5-11.5T640-800q0-17 11.5-28.5T680-840h120q17 0 28.5 11.5T840-800v120q0 17-11.5 28.5T800-640q-17 0-28.5-11.5T760-680v-80Z";
    private readonly string exitFullscreenPath = "M240-240h-80q-17 0-28.5-11.5T120-280q0-17 11.5-28.5T160-320h120q17 0 28.5 11.5T320-280v120q0 17-11.5 28.5T280-120q-17 0-28.5-11.5T240-160v-80Zm480 0v80q0 17-11.5 28.5T680-120q-17 0-28.5-11.5T640-160v-120q0-17 11.5-28.5T680-320h120q17 0 28.5 11.5T840-280q0 17-11.5 28.5T800-240h-80ZM240-720v-80q0-17 11.5-28.5T280-840q17 0 28.5 11.5T320-800v120q0 17-11.5 28.5T280-640H160q-17 0-28.5-11.5T120-680q0-17 11.5-28.5T160-720h80Zm480 0h80q17 0 28.5 11.5T840-680q0 17-11.5 28.5T800-640H680q-17 0-28.5-11.5T640-680v-120q0-17 11.5-28.5T680-840q17 0 28.5 11.5T720-800v80Z";
    private WindowState previousWindowState;
    private bool isTransferredToUI;
    private int? selectedProcessId;
    private readonly Dictionary<string, int> notifications = new Dictionary<string, int>();
    private Storyboard currentNotification;
    private bool isNotifying;
    private int tabReferences;
    private readonly AIChat aiChat;
    private bool isAIPanelOpen = true;
    private int aiReferences;
    private bool isSearching;
    private string lastQuery;
    private int currentPage = 1;
    private int totalPages = 1;
    private Advertisement currentAdvertisement;
    private readonly Timer saveTabTimer = new Timer(60000.0);
    internal MainWindow HomeWindow;
    internal Grid InvisiGrid;
    internal Border MainBorder;
    internal Grid MainGrid;
    internal Grid MainContainer;
    internal BlurEffect MainBlur;
    internal Grid TopGrid;
    internal Rectangle TopSeparator;
    internal DockPanel TopPanel;
    internal Button CloseButton;
    internal Button MaximiseButton;
    internal Button MinimiseButton;
    internal Image BloomIcon;
    internal Grid SideGrid;
    internal Rectangle SideSeparator;
    internal StackPanel SidePanel;
    internal TabCheckBox HomeButton;
    internal TabCheckBox EditorButton;
    internal TabCheckBox ScriptsButton;
    internal TabCheckBox SettingsButton;
    internal Grid TabContainer;
    internal Grid HomeTab;
    internal Grid EditorTab;
    internal Rectangle AISeparator;
    internal Rectangle EditorSeparator;
    internal StackPanel EditorButtonPanel;
    internal Button SelectedProcessButton;
    internal Button OpenFileButton;
    internal Button SaveFileButton;
    internal Button ClearButton;
    internal Button ExecuteButton;
    internal Button AIToggleButton;
    internal ScrollViewer AIChatScroll;
    internal StackPanel AIChatPanel;
    internal AIBotMessage LoadingAI;
    internal Rectangle TabSeparator;
    internal Grid AIInputGrid;
    internal System.Windows.Shapes.Path AIInputPath;
    internal TextBox AIInput;
    internal TabControl ScriptTabs;
    internal Grid ScriptsTab;
    internal TextBox SearchQuery;
    internal Button SearchBtn;
    internal ScrollViewer SearchResultScroll;
    internal WrapPanel SearchResultPanel;
    internal Button NextPageBtn;
    internal Button PreviousPageBtn;
    internal Button ScriptBloxCredits;
    internal Border CurrentPageBorder;
    internal Label CurrentPageLabel;
    internal Grid SettingsTab;
    internal Rectangle SettingsSeparator;
    internal StackPanel SettingsHeaderStack;
    internal Button ExecutorHeaderButton;
    internal Button EditorHeaderButton;
    internal Button AIHeaderButton;
    internal ScrollViewer SettingsScroll;
    internal StackPanel SettingsStack;
    internal Grid ExecutorHeader;
    internal System.Windows.Shapes.Path ExecutorHeaderPath;
    internal Label ExecutorHeaderLabel;
    internal SettingCheckBox MultiInstance;
    internal SettingCheckBox AutoExecute;
    internal SettingCheckBox SaveTabs;
    internal SettingCheckBox TopMost;
    internal Grid EditorHeader;
    internal System.Windows.Shapes.Path EditorHeaderPath;
    internal Label EditorHeaderLabel;
    internal SettingSlider EditorRefreshRate;
    internal SettingSlider EditorTextSize;
    internal SettingCheckBox ShowMinimap;
    internal SettingCheckBox ShowInlayHints;
    internal Grid AIHeader;
    internal System.Windows.Shapes.Path AIHeaderPath;
    internal Label AIHeaderLabel;
    internal SettingCheckBox UseConversationHistory;
    internal SettingCheckBox AppendCurrentScript;
    internal SettingButton ClearConversationHistory;
    internal Border NotificationBorder;
    internal Grid NotificationGrid;
    internal TextBlock NotificationContent;
    internal Border DurationIndicator;
    internal Button CloseNotificationButton;
    internal Grid InstancePopupGrid;
    internal Border InstanceBorder;
    internal Grid InstanceGrid;
    internal Grid InstanceTopGrid;
    internal Rectangle InstanceTopSeparator;
    internal Button CloseInstanceButton;
    internal Label InstanceTitle;
    internal ScrollViewer InstanceScroll;
    internal StackPanel InstanceStack;
    internal Border InstanceBackgroundBorder;
    internal Grid LoginPopupGrid;
    internal Border LoginBorder;
    internal Border LoginBackgroundBorder;
    internal Border AdBorder;
    internal Grid AdGrid;
    internal Button CloseAdButton;
    private bool _contentLoaded;

    private void DoNotification()
    {
      this.isNotifying = true;
      KeyValuePair<string, int> keyValuePair = this.notifications.First<KeyValuePair<string, int>>();
      this.notifications.Remove(keyValuePair.Key);
      this.NotificationContent.Text = keyValuePair.Key;
      this.DurationIndicator.Width = 0.0;
      this.currentNotification = Wave.Classes.Cosmetic.Animation.Animate(new AnimationPropertyBase((object) this.NotificationBorder)
      {
        Property = (object) FrameworkElement.WidthProperty,
        To = (object) 280
      }, new AnimationPropertyBase((object) this.DurationIndicator)
      {
        Property = (object) FrameworkElement.WidthProperty,
        To = (object) 278,
        Duration = new Duration(TimeSpan.FromMilliseconds((double) keyValuePair.Value)),
        DisableEasing = true
      });
      this.currentNotification.Completed += (EventHandler) ((sender, e) => this.CloseNotification());
    }

    private void CloseNotification()
    {
      Wave.Classes.Cosmetic.Animation.Animate(new AnimationPropertyBase((object) this.NotificationBorder)
      {
        Property = (object) FrameworkElement.WidthProperty,
        To = (object) 0
      }, new AnimationPropertyBase((object) this.DurationIndicator)
      {
        Property = (object) FrameworkElement.WidthProperty,
        To = (object) 0
      }).Completed += (EventHandler) (async (sender2, e2) =>
      {
        if (this.notifications.Count > 0)
        {
          await Task.Delay(250);
          this.DoNotification();
        }
        else
          this.isNotifying = false;
      });
    }

    private void PopupNotification(string message, int duration = 2500)
    {
      this.notifications.Add(message, duration);
      if (this.isNotifying)
        return;
      Application.Current.Dispatcher.Invoke((Action) (() => this.DoNotification()));
    }

    private void NewTab(string tabName = "x", string content = "print('Hello World!');", bool autoSave = true)
    {
      if (tabName == "x")
      {
        ++this.tabReferences;
        tabName = "Tab " + this.tabReferences.ToString() + ".lua";
      }
      TabItem tabItem = new TabItem();
      tabItem.BorderThickness = new Thickness(0.0);
      tabItem.FontFamily = new FontFamily("SF Pro");
      tabItem.FontSize = 14.0;
      tabItem.Foreground = (Brush) new SolidColorBrush(Colors.Gainsboro);
      tabItem.Header = (object) tabName;
      tabItem.Height = 40.0;
      tabItem.Margin = new Thickness(-2.0, -2.0, -2.0, 0.0);
      TabItem newItem = tabItem;
      ChromiumWebBrowser chromiumWebBrowser = new ChromiumWebBrowser();
      chromiumWebBrowser.BorderThickness = new Thickness(0.0);
      ChromiumWebBrowser newBrowser = chromiumWebBrowser;
      newBrowser.FrameLoadEnd += (EventHandler<FrameLoadEndEventArgs>) (async (sender, e) =>
      {
        await Task.Delay(1000);
        newBrowser.ExecuteScriptAsync("\r\n                    window.setText('" + HttpUtility.JavaScriptStringEncode(content) + "');\r\n                    window.updateOptions({\r\n                        minimap: {\r\n                            enabled: " + Wave.Classes.Passive.Settings.Instance.ShowMinimap.ToString().ToLower() + "\r\n                        },\r\n                        inlayHints: {\r\n                            enabled: " + Wave.Classes.Passive.Settings.Instance.ShowInlayHints.ToString().ToLower() + "\r\n                        },\r\n                        fontSize: " + Wave.Classes.Passive.Settings.Instance.EditorTextSize.ToString() + "\r\n                    });\r\n                ");
        newBrowser.GetBrowserHost().WindowlessFrameRate = Wave.Classes.Passive.Settings.Instance.EditorRefreshRate;
        if (!(Wave.Classes.Passive.Settings.Instance.SaveTabs & autoSave))
          return;
        Application.Current.Dispatcher.Invoke((Action) (() => this.AutoSaveTabs()));
      });
      newItem.Content = (object) newBrowser;
      newBrowser.Load("http://localhost:1111");
      newItem.IsSelected = true;
      this.ScriptTabs.Items.Add((object) newItem);
    }

    private void RemoveTab(string tabName)
    {
      if (this.ScriptTabs.Items.Count <= 1)
        return;
      foreach (TabItem removeItem in (IEnumerable) this.ScriptTabs.Items)
      {
        if ((string) removeItem.Header == tabName)
        {
          this.ScriptTabs.Items.Remove((object) removeItem);
          break;
        }
      }
      string path = "data/tabs/" + tabName;
      if (File.Exists(path))
        File.Delete(path);
      ((TabItem) this.ScriptTabs.Items[0]).IsSelected = true;
    }

    private async void AutoSaveTabs()
    {
      foreach (string file in Directory.GetFiles("data/tabs"))
        File.Delete(file);
      TabItem[] tabItemArray = this.ScriptTabs.Items.Cast<TabItem>().ToArray<TabItem>();
      for (int index = 0; index < tabItemArray.Length; ++index)
      {
        TabItem tabItem = tabItemArray[index];
        ChromiumWebBrowser content = (ChromiumWebBrowser) tabItem.Content;
        if (content.CanExecuteJavascriptInMainFrame)
        {
          object result = (await content.EvaluateScriptAsync("window.getText();", new TimeSpan?(), false)).Result;
          if (result != null)
            File.WriteAllText(Environment.CurrentDirectory + "/data/tabs/" + tabItem.Header?.ToString(), result.ToString());
        }
        tabItem = (TabItem) null;
      }
      tabItemArray = (TabItem[]) null;
    }

    private async void SendAIMessage(string message)
    {
      this.PopupNotification("This is just a preview, AI is disabled for now ;)", 4000);
    }

    private string GetApiLink(string query, int page)
    {
      return query == "" ? "https://scriptblox.com/api/script/fetch?page=" + page.ToString() : "https://scriptblox.com/api/script/search?filters=free&page=" + page.ToString() + "&q=" + query;
    }

    private void SetCurrentPage(int page)
    {
      this.currentPage = page;
      this.CurrentPageLabel.Content = (object) ("Page " + page.ToString() + "/" + this.totalPages.ToString());
    }

    private async void SearchScripts(string query = "", int page = 1)
    {
      MainWindow mainWindow1 = this;
      if (mainWindow1.isSearching)
        return;
      mainWindow1.isSearching = true;
      mainWindow1.lastQuery = query;
      try
      {
        mainWindow1.SearchResultPanel.Children.Clear();
        using (HttpClient client = new HttpClient())
        {
          JToken jtoken = JToken.Parse(await (await client.GetAsync(mainWindow1.GetApiLink(query, page))).Content.ReadAsStringAsync())[(object) "result"];
          foreach (ScriptObject scriptObject1 in JsonConvert.DeserializeObject<ScriptObject[]>(jtoken[(object) "scripts"].ToString()))
          {
            MainWindow mainWindow = mainWindow1;
            ScriptObject scriptObject = scriptObject1;
            ScriptResult element = new ScriptResult(scriptObject);
            ((ButtonBase) element.FindName("ExecuteButton")).Click += (RoutedEventHandler) (async (sender, e) =>
            {
              string script = await scriptObject.GetScript();
              if (mainWindow.InstanceStack.Children.Count > 1)
              {
                foreach (InstancePanel child in mainWindow.InstanceStack.Children)
                  child.Script = script;
                mainWindow.AnimatePopupIn(mainWindow.InstancePopupGrid);
              }
              else
                Roblox.ExecuteAll(script);
            });
            mainWindow1.SearchResultPanel.Children.Add((UIElement) element);
          }
          mainWindow1.totalPages = Math.Max((int) jtoken[(object) "totalPages"], 1);
        }
        mainWindow1.SetCurrentPage(page);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
      }
      finally
      {
        mainWindow1.isSearching = false;
      }
    }

    private void ShowAdPane()
    {
      if (this.AdBorder.Visibility == Visibility.Collapsed)
      {
        this.MainBorder.Margin = new Thickness(4.0, 4.0, 4.0, 124.0);
        this.Height += 120.0;
        this.AdBorder.Visibility = Visibility.Visible;
      }
      this.MinHeight = 570.0;
    }

    private void HideAdPane()
    {
      this.MinHeight = 450.0;
      if (this.AdBorder.Visibility != Visibility.Visible)
        return;
      this.AdBorder.Visibility = Visibility.Collapsed;
      this.MainBorder.Margin = new Thickness(4.0, 4.0, 4.0, 4.0);
      this.Height -= 120.0;
    }

    private void LoadAd()
    {
      this.currentAdvertisement = Advertisements.GetAdvertisement();
      this.AdBorder.Background = (Brush) new ImageBrush()
      {
        ImageSource = (ImageSource) new BitmapImage(new Uri("pack://application:,,,/Wave;component" + this.currentAdvertisement.localImageLink, UriKind.Absolute))
      };
      this.ShowAdPane();
    }

    private void InitializeAds()
    {
      this.LoadAd();
      Timer timer = new Timer(300000.0);
      timer.Elapsed += (ElapsedEventHandler) ((sender, e) => Application.Current.Dispatcher.Invoke((Action) (() => this.LoadAd())));
      timer.Start();
    }

    private Storyboard AnimatePopupIn(Grid popupGrid)
    {
      popupGrid.Opacity = 0.0;
      popupGrid.Visibility = Visibility.Visible;
      Storyboard storyboard = Wave.Classes.Cosmetic.Animation.Animate(new AnimationPropertyBase((object) popupGrid)
      {
        Property = (object) UIElement.OpacityProperty,
        To = (object) 1
      });
      BlurEffect mainBlur = this.MainBlur;
      DependencyProperty radiusProperty = BlurEffect.RadiusProperty;
      DoubleAnimation animation = new DoubleAnimation();
      animation.To = new double?(8.0);
      animation.Duration = (Duration) TimeSpan.FromSeconds(0.35);
      mainBlur.BeginAnimation(radiusProperty, (AnimationTimeline) animation);
      return storyboard;
    }

    private Storyboard AnimatePopupOut(Grid popupGrid)
    {
      Storyboard storyboard = Wave.Classes.Cosmetic.Animation.Animate(new AnimationPropertyBase((object) popupGrid)
      {
        Property = (object) UIElement.OpacityProperty,
        To = (object) 0
      });
      BlurEffect mainBlur = this.MainBlur;
      DependencyProperty radiusProperty = BlurEffect.RadiusProperty;
      DoubleAnimation animation = new DoubleAnimation();
      animation.To = new double?(0.0);
      animation.Duration = (Duration) TimeSpan.FromSeconds(0.35);
      mainBlur.BeginAnimation(radiusProperty, (AnimationTimeline) animation);
      storyboard.Completed += (EventHandler) ((sender, e) => popupGrid.Visibility = Visibility.Collapsed);
      return storyboard;
    }

    private async void InitiateLogin()
    {
      if (await this.ValidateLogin())
        this.TransferToUI();
      else
        this.AnimatePopupIn(this.LoginPopupGrid);
    }

    private async Task<bool> ValidateLogin()
    {
      bool flag;
      return flag;
    }

    private void TransferToUI()
    {
      this.LoginPopupGrid.Visibility = Visibility.Collapsed;
      WebSocketCollection.AddSocket("clientInformation", 6001).AddBehaviour<ClientInformationBehavior>("/transferClientInformation");
      foreach (KeyValuePair<string, WebSocket> socket in WebSocketCollection.Sockets)
        socket.Value.Server.Start();
      Roblox.OnProcessFound += (EventHandler<RobloxInstanceEventArgs>) ((sender2, e2) =>
      {
        if (e2.AlreadyOpen)
          return;
        this.PopupNotification("Attaching...");
      });
      Roblox.OnProcessAdded += (EventHandler<RobloxInstanceEventArgs>) ((sender2, e2) =>
      {
        if (!e2.AlreadyOpen)
          this.PopupNotification("Attached!");
        Application.Current.Dispatcher.Invoke<Task>((Func<Task>) (async () =>
        {
          InstancePanel instancePanel = new InstancePanel()
          {
            Margin = new Thickness(4.0, 2.0, 4.0, 2.0),
            Width = double.NaN,
            ProcessID = e2.Id
          };
          Task.Run((Func<Task>) (async () =>
          {
            InstancePanel instancePanel2 = instancePanel;
            instancePanel2.Script = (await ((IChromiumWebBrowserBase) this.ScriptTabs.SelectedContent).EvaluateScriptAsync("window.getText();", new TimeSpan?(), false)).Result.ToString();
            instancePanel2 = (InstancePanel) null;
          }));
          ((ButtonBase) instancePanel.FindName("SelectButton")).Click += (RoutedEventHandler) ((sender3, e3) => this.UpdateSelectedProcessID(new int?(e2.Id), instancePanel.Username));
          this.InstanceStack.Children.Add((UIElement) instancePanel);
          if (this.InstanceStack.Children.Count != 1)
            ;
          else
          {
            while (instancePanel.Username == "Username")
              await Task.Delay(250);
            this.UpdateSelectedProcessID(new int?(e2.Id), instancePanel.Username);
          }
        }));
      });
      Roblox.OnProcessRemoved += (EventHandler<RobloxInstanceEventArgs>) ((sender2, e2) =>
      {
        foreach (InstancePanel child in this.InstanceStack.Children)
        {
          if (child.ProcessID == e2.Id)
          {
            this.InstanceStack.Children.Remove((UIElement) child);
            break;
          }
        }
        if (this.InstanceStack.Children.Count == 0)
        {
          this.UpdateSelectedProcessID(new int?(), (string) null);
        }
        else
        {
          int? selectedProcessId = this.selectedProcessId;
          int id = e2.Id;
          if (!(selectedProcessId.GetValueOrDefault() == id & selectedProcessId.HasValue))
            return;
          this.UpdateSelectedProcessID(new int?(((InstancePanel) this.InstanceStack.Children[0]).ProcessID), ((InstancePanel) this.InstanceStack.Children[0]).Username);
        }
      });
      Roblox.OnProcessInformationGained += (EventHandler<DetailedRobloxInstanceEventArgs>) ((sender2, e2) => Application.Current.Dispatcher.Invoke((Action) (() =>
      {
        foreach (InstancePanel child in this.InstanceStack.Children)
        {
          if (child.ProcessID == e2.ProcessId)
          {
            child.Username = e2.Username;
            child.UserID = e2.UserId;
          }
        }
      })));
      Roblox.Start();
      this.MultiInstance.IsChecked = Wave.Classes.Passive.Settings.Instance.MultiInstance;
      this.AutoExecute.IsChecked = Wave.Classes.Passive.Settings.Instance.AutoExecute;
      this.SaveTabs.IsChecked = Wave.Classes.Passive.Settings.Instance.SaveTabs;
      this.TopMost.IsChecked = Wave.Classes.Passive.Settings.Instance.TopMost;
      this.EditorRefreshRate.Value = (double) Wave.Classes.Passive.Settings.Instance.EditorRefreshRate;
      this.EditorTextSize.Value = Wave.Classes.Passive.Settings.Instance.EditorTextSize;
      this.ShowMinimap.IsChecked = Wave.Classes.Passive.Settings.Instance.ShowMinimap;
      this.ShowInlayHints.IsChecked = Wave.Classes.Passive.Settings.Instance.ShowInlayHints;
      this.UseConversationHistory.IsChecked = Wave.Classes.Passive.Settings.Instance.UseConversationHistory;
      this.AppendCurrentScript.IsChecked = Wave.Classes.Passive.Settings.Instance.AppendCurrentScript;
      this.saveTabTimer.Elapsed += (ElapsedEventHandler) ((sender2, e2) =>
      {
        if (!Wave.Classes.Passive.Settings.Instance.SaveTabs)
          return;
        Application.Current.Dispatcher.Invoke((Action) (() => this.AutoSaveTabs()));
      });
      string[] allowedExtensions = new string[3]
      {
        ".lua",
        ".luau",
        ".txt"
      };
      string[] array = ((IEnumerable<string>) Directory.GetFiles("data/tabs")).Where<string>((Func<string, bool>) (s => ((IEnumerable<string>) allowedExtensions).Contains<string>(System.IO.Path.GetExtension(s).ToLowerInvariant()))).ToArray<string>();
      if (array.Length != 0)
      {
        foreach (string path in array)
        {
          string fileName = System.IO.Path.GetFileName(path);
          Match match1 = Regex.Match(fileName, "Tab (\\d+).lua");
          if (match1.Success)
          {
            int num = int.Parse(match1.Groups[1].Value);
            if (num > this.tabReferences)
              this.tabReferences = num;
          }
          Match match2 = Regex.Match(fileName, "AI Reference (\\d+).lua");
          if (match2.Success)
          {
            int num = int.Parse(match2.Groups[1].Value);
            if (num > this.aiReferences)
              this.aiReferences = num;
          }
          this.NewTab(fileName, File.ReadAllText(path), false);
        }
      }
      else
        this.NewTab();
      this.InitializeAds();
      this.SearchScripts();
      this.Topmost = this.TopMost.IsChecked;
      this.isTransferredToUI = true;
    }

    public override void OnApplyTemplate()
    {
      HwndSource.FromHwnd(new WindowInteropHelper((Window) this).Handle).AddHook(new HwndSourceHook(MainWindow.WindowProc));
    }

    private static IntPtr WindowProc(
      IntPtr hwnd,
      int msg,
      IntPtr wParam,
      IntPtr lParam,
      ref bool handled)
    {
      if (msg == 36)
      {
        MainWindow.WmGetMinMaxInfo(hwnd, lParam);
        handled = false;
      }
      return (IntPtr) 0;
    }

    private static void WmGetMinMaxInfo(IntPtr hwnd, IntPtr lParam)
    {
      MainWindow.MINMAXINFO structure = (MainWindow.MINMAXINFO) Marshal.PtrToStructure(lParam, typeof (MainWindow.MINMAXINFO));
      int flags = 2;
      IntPtr hMonitor = MainWindow.MonitorFromWindow(hwnd, flags);
      if (hMonitor != IntPtr.Zero)
      {
        MainWindow.MONITORINFO lpmi = new MainWindow.MONITORINFO();
        MainWindow.GetMonitorInfo(hMonitor, lpmi);
        MainWindow.RECT rcWork = lpmi.rcWork;
        MainWindow.RECT rcMonitor = lpmi.rcMonitor;
        structure.ptMaxPosition.x = Math.Abs(rcWork.left - rcMonitor.left);
        structure.ptMaxPosition.y = Math.Abs(rcWork.top - rcMonitor.top);
        structure.ptMaxSize.x = Math.Abs(rcWork.right - rcWork.left);
        structure.ptMaxSize.y = Math.Abs(rcWork.bottom - rcWork.top);
      }
      Marshal.StructureToPtr<MainWindow.MINMAXINFO>(structure, lParam, true);
    }

    [DllImport("user32")]
    internal static extern bool GetMonitorInfo(IntPtr hMonitor, MainWindow.MONITORINFO lpmi);

    [DllImport("user32.dll")]
    private static extern bool GetCursorPos(ref Point lpPoint);

    [DllImport("User32")]
    internal static extern IntPtr MonitorFromWindow(IntPtr handle, int flags);

    private void UpdateSelectedProcessID(int? id, string username)
    {
      this.selectedProcessId = id;
      this.SelectedProcessButton.Content = (object) username;
      this.SelectedProcessButton.Visibility = !id.HasValue ? Visibility.Collapsed : Visibility.Visible;
    }

    public MainWindow()
    {
      MainWindow mainWindow = this;
      this.InitializeComponent();
      this.previousWindowState = this.WindowState;
      this.InstancePopupGrid.Visibility = Visibility.Collapsed;
      this.SelectedProcessButton.Visibility = Visibility.Collapsed;
      KeyValuePair<TabCheckBox, Grid>[] tabCheckBoxes = new KeyValuePair<TabCheckBox, Grid>[4]
      {
        new KeyValuePair<TabCheckBox, Grid>(this.HomeButton, this.HomeTab),
        new KeyValuePair<TabCheckBox, Grid>(this.EditorButton, this.EditorTab),
        new KeyValuePair<TabCheckBox, Grid>(this.ScriptsButton, this.ScriptsTab),
        new KeyValuePair<TabCheckBox, Grid>(this.SettingsButton, this.SettingsTab)
      };
      foreach (KeyValuePair<TabCheckBox, Grid> keyValuePair1 in tabCheckBoxes)
      {
        KeyValuePair<TabCheckBox, Grid> tab = keyValuePair1;
        tab.Value.Visibility = Visibility.Collapsed;
        TabCheckBox checkBox = tab.Key;
        checkBox.OnEnabled += (EventHandler) ((sender, e) =>
        {
          checkBox.CanToggle = false;
          tab.Value.Visibility = Visibility.Visible;
          foreach (KeyValuePair<TabCheckBox, Grid> keyValuePair2 in tabCheckBoxes)
          {
            TabCheckBox key = keyValuePair2.Key;
            if (key.Enabled && key != checkBox)
            {
              key.CanToggle = true;
              key.Enabled = false;
            }
          }
        });
        checkBox.OnDisabled += (EventHandler) ((sender, e) => tab.Value.Visibility = Visibility.Collapsed);
      }
      KeyValuePair<Button, Grid>[] keyValuePairArray = new KeyValuePair<Button, Grid>[3]
      {
        new KeyValuePair<Button, Grid>(this.ExecutorHeaderButton, this.ExecutorHeader),
        new KeyValuePair<Button, Grid>(this.EditorHeaderButton, this.EditorHeader),
        new KeyValuePair<Button, Grid>(this.AIHeaderButton, this.AIHeader)
      };
      foreach (KeyValuePair<Button, Grid> keyValuePair in keyValuePairArray)
      {
        KeyValuePair<Button, Grid> settingsCategory = keyValuePair;
        settingsCategory.Key.Click += (RoutedEventHandler) ((sender, e) => closure_0.SettingsScroll.ScrollToVerticalOffset(settingsCategory.Value.TranslatePoint(new Point(), (UIElement) closure_0.SettingsStack).Y));
      }
      this.LoginPopupGrid.Opacity = 0.0;
      this.MainBlur.Radius = 0.0;
      this.NotificationBorder.Width = 0.0;
      this.HideAdPane();
      tabCheckBoxes[1].Key.Enabled = true;
      this.aiChat = new AIChat();
    }

    private void HomeWindow_Loaded(object sender, RoutedEventArgs e) => this.InitiateLogin();

    private void HomeWindow_Closing(object sender, CancelEventArgs e)
    {
      if (!Wave.Classes.Passive.Settings.Instance.SaveTabs)
        return;
      this.AutoSaveTabs();
    }

    private void HomeWindow_SourceInitialized(object sender, EventArgs e)
    {
      HwndSource.FromHwnd(new WindowInteropHelper((Window) this).Handle).AddHook(new HwndSourceHook(MainWindow.WindowProc));
    }

    private void HomeWindow_MouseDown(object sender, MouseButtonEventArgs e)
    {
      if (e.ChangedButton != MouseButton.Left)
        return;
      try
      {
        this.DragMove();
      }
      catch
      {
      }
    }

    private void HomeWindow_SizeChanged(object sender, SizeChangedEventArgs e)
    {
      if (this.WindowState == this.previousWindowState)
        return;
      this.previousWindowState = this.WindowState;
      this.MaximiseButton.Content = this.WindowState == WindowState.Maximized ? (object) this.exitFullscreenPath : (object) this.fullscreenPath;
    }

    private void CloseButton_Click(object sender, RoutedEventArgs e) => Environment.Exit(0);

    private void MaximiseButton_Click(object sender, RoutedEventArgs e)
    {
      this.WindowState = this.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
    }

    private void MinimiseButton_Click(object sender, RoutedEventArgs e)
    {
      this.WindowState = WindowState.Minimized;
    }

    private void NewTabButton_Click(object sender, RoutedEventArgs e) => this.NewTab();

    private void CloseTabButton_Click(object sender, RoutedEventArgs e)
    {
      this.RemoveTab((string) ((HeaderedContentControl) ((FrameworkElement) sender).TemplatedParent).Header);
    }

    private void TabHeaderScroll_ScrollChanged(object sender, ScrollChangedEventArgs e)
    {
      if (e.ExtentWidthChange <= 0.0)
        return;
      ((ScrollViewer) sender).ScrollToRightEnd();
    }

    private async void ExecuteButton_Click(object sender, RoutedEventArgs e)
    {
      if (!this.selectedProcessId.HasValue)
        return;
      int[] processIds = new int[1]
      {
        this.selectedProcessId.Value
      };
      Roblox.ExecuteSpecific(processIds, (await ((IChromiumWebBrowserBase) this.ScriptTabs.SelectedContent).EvaluateScriptAsync("window.getText();", new TimeSpan?(), false)).Result.ToString());
      processIds = (int[]) null;
    }

    private void ClearButton_Click(object sender, RoutedEventArgs e)
    {
      ((IChromiumWebBrowserBase) this.ScriptTabs.SelectedContent).ExecuteScriptAsync("window.setText('');");
    }

    private void OpenFileButton_Click(object sender, RoutedEventArgs e)
    {
      OpenFileDialog openFileDialog1 = new OpenFileDialog();
      openFileDialog1.Title = "Wave - Open Script";
      openFileDialog1.Filter = "Lua Script|*.lua|Text File|*.txt";
      OpenFileDialog openFileDialog2 = openFileDialog1;
      bool? nullable = openFileDialog2.ShowDialog();
      bool flag = true;
      if (!(nullable.GetValueOrDefault() == flag & nullable.HasValue))
        return;
      this.NewTab(System.IO.Path.GetFileName(openFileDialog2.FileName), File.ReadAllText(openFileDialog2.FileName));
    }

    private async void SaveFileButton_Click(object sender, RoutedEventArgs e)
    {
      Encoding encoding = Encoding.UTF8;
      byte[] bytes = encoding.GetBytes((await ((IChromiumWebBrowserBase) this.ScriptTabs.SelectedContent).EvaluateScriptAsync("window.getText();", new TimeSpan?(), false)).Result.ToString());
      encoding = (Encoding) null;
      SaveFileDialog saveFileDialog1 = new SaveFileDialog();
      saveFileDialog1.Title = "Wave - Save Script";
      saveFileDialog1.Filter = "Lua Script|*.lua";
      SaveFileDialog saveFileDialog2 = saveFileDialog1;
      bool? nullable = saveFileDialog2.ShowDialog();
      bool flag = true;
      if (!(nullable.GetValueOrDefault() == flag & nullable.HasValue))
        return;
      FileStream fileStream = (FileStream) saveFileDialog2.OpenFile();
      fileStream.Write(bytes, 0, bytes.Length);
      fileStream.Close();
    }

    private void AIToggleButton_Click(object sender, RoutedEventArgs e)
    {
      this.isAIPanelOpen = !this.isAIPanelOpen;
      Wave.Classes.Cosmetic.Animation.Animate(new AnimationPropertyBase((object) this.AIChatScroll)
      {
        Property = (object) FrameworkElement.WidthProperty,
        To = (object) (this.isAIPanelOpen ? 216 : 0)
      }, new AnimationPropertyBase((object) this.AIInputGrid)
      {
        Property = (object) FrameworkElement.WidthProperty,
        To = (object) (this.isAIPanelOpen ? 216 : 0)
      });
    }

    private void AIInput_GotFocus(object sender, RoutedEventArgs e) => this.AIInput.Text = "";

    private void AIInput_LostFocus(object sender, RoutedEventArgs e)
    {
      this.AIInput.Text = "Send a message...";
    }

    private void AIInput_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.Key != Key.Return)
        return;
      if (this.AIInput.Text.Length > 0)
        this.SendAIMessage(this.AIInput.Text);
      FocusManager.SetFocusedElement(FocusManager.GetFocusScope((DependencyObject) this.AIInput), (IInputElement) null);
      Keyboard.ClearFocus();
      this.AIInput.Text = "Send a message...";
    }

    private void SearchQuery_GotFocus(object sender, RoutedEventArgs e)
    {
      this.SearchQuery.Text = "";
    }

    private void SearchQuery_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.Key != Key.Return)
        return;
      FocusManager.SetFocusedElement(FocusManager.GetFocusScope((DependencyObject) this.SearchQuery), (IInputElement) null);
      Keyboard.ClearFocus();
      this.SearchScripts(this.SearchQuery.Text);
      if (this.SearchQuery.Text.Length != 0)
        return;
      this.SearchQuery.Text = "Enter your search query...";
    }

    private void SearchQuery_LostFocus(object sender, RoutedEventArgs e)
    {
      if (this.SearchQuery.Text.Length != 0)
        return;
      this.SearchQuery.Text = "Enter your search query...";
    }

    private void SearchBtn_Click(object sender, RoutedEventArgs e)
    {
      this.SearchScripts(this.SearchQuery.Text);
      if (this.SearchQuery.Text.Length != 0)
        return;
      this.SearchQuery.Text = "Enter your search query...";
    }

    private void NextPageBtn_Click(object sender, RoutedEventArgs e)
    {
      if (this.currentPage >= this.totalPages)
        return;
      this.SearchScripts(this.lastQuery, this.currentPage + 1);
    }

    private void PreviousPageBtn_Click(object sender, RoutedEventArgs e)
    {
      if (this.currentPage <= 1)
        return;
      this.SearchScripts(this.lastQuery, this.currentPage - 1);
    }

    private void ScriptBloxCredits_Click(object sender, RoutedEventArgs e)
    {
      Process.Start("https://scriptblox.com");
    }

    private void CloseNotificationButton_Click(object sender, RoutedEventArgs e)
    {
      if (this.currentNotification.GetCurrentState() != ClockState.Active)
        return;
      this.currentNotification.Stop();
      this.CloseNotification();
    }

    private void CloseAdButton_Click(object sender, RoutedEventArgs e) => this.HideAdPane();

    private void AdBorder_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
      Process.Start(this.currentAdvertisement.redirectLink);
    }

    private void MultiInstance_OnCheckedChanged(object sender, EventArgs e)
    {
      Wave.Classes.Passive.Settings.Instance.MultiInstance = this.MultiInstance.IsChecked;
      Wave.Classes.Passive.Settings.Instance.Save();
      Bloxstrap.Instance.MultiInstanceLaunching = this.MultiInstance.IsChecked;
      Bloxstrap.Instance.Save();
    }

    private void AutoExecute_OnCheckedChanged(object sender, EventArgs e)
    {
      Wave.Classes.Passive.Settings.Instance.AutoExecute = this.AutoExecute.IsChecked;
      Wave.Classes.Passive.Settings.Instance.Save();
    }

    private void SaveTabs_OnCheckedChanged(object sender, EventArgs e)
    {
      Wave.Classes.Passive.Settings.Instance.SaveTabs = this.SaveTabs.IsChecked;
      Wave.Classes.Passive.Settings.Instance.Save();
      if (!this.isTransferredToUI)
        return;
      if (this.SaveTabs.IsChecked)
      {
        this.AutoSaveTabs();
        this.saveTabTimer.Start();
      }
      else
      {
        this.saveTabTimer.Stop();
        foreach (string file in Directory.GetFiles("data/tabs"))
          File.Delete(file);
      }
    }

    private void EditorRefreshRate_OnValueChanged(object sender, EventArgs e)
    {
      Wave.Classes.Passive.Settings.Instance.EditorRefreshRate = (int) this.EditorRefreshRate.Value;
      Wave.Classes.Passive.Settings.Instance.Save();
      foreach (ContentControl contentControl in (IEnumerable) this.ScriptTabs.Items)
        ((IChromiumWebBrowserBase) contentControl.Content).GetBrowserHost().WindowlessFrameRate = Wave.Classes.Passive.Settings.Instance.EditorRefreshRate;
    }

    private void EditorTextSize_OnValueChanged(object sender, EventArgs e)
    {
      Wave.Classes.Passive.Settings.Instance.EditorTextSize = this.EditorTextSize.Value;
      Wave.Classes.Passive.Settings.Instance.Save();
      foreach (ContentControl contentControl in (IEnumerable) this.ScriptTabs.Items)
        ((IChromiumWebBrowserBase) contentControl.Content).ExecuteScriptAsync("window.updateOptions({ fontSize: " + Wave.Classes.Passive.Settings.Instance.EditorTextSize.ToString() + " });");
    }

    private void ShowMinimap_OnCheckedChanged(object sender, EventArgs e)
    {
      Wave.Classes.Passive.Settings.Instance.ShowMinimap = this.ShowMinimap.IsChecked;
      Wave.Classes.Passive.Settings.Instance.Save();
      foreach (ContentControl contentControl in (IEnumerable) this.ScriptTabs.Items)
        ((IChromiumWebBrowserBase) contentControl.Content).ExecuteScriptAsync("window.updateOptions({ minimap: { enabled: " + Wave.Classes.Passive.Settings.Instance.ShowMinimap.ToString().ToLower() + "} });");
    }

    private void ShowInlayHints_OnCheckedChanged(object sender, EventArgs e)
    {
      Wave.Classes.Passive.Settings.Instance.ShowInlayHints = this.ShowInlayHints.IsChecked;
      Wave.Classes.Passive.Settings.Instance.Save();
      foreach (ContentControl contentControl in (IEnumerable) this.ScriptTabs.Items)
        ((IChromiumWebBrowserBase) contentControl.Content).ExecuteScriptAsync("window.updateOptions({ inlayHints: { enabled: " + Wave.Classes.Passive.Settings.Instance.ShowInlayHints.ToString().ToLower() + "} });");
    }

    private void UseConversationHistory_OnCheckedChanged(object sender, EventArgs e)
    {
      Wave.Classes.Passive.Settings.Instance.UseConversationHistory = this.UseConversationHistory.IsChecked;
      Wave.Classes.Passive.Settings.Instance.Save();
    }

    private void TopMost_OnCheckedChanged(object sender, EventArgs e)
    {
      Wave.Classes.Passive.Settings.Instance.TopMost = this.TopMost.IsChecked;
      Wave.Classes.Passive.Settings.Instance.Save();
      this.Topmost = this.TopMost.IsChecked;
    }

    private void AppendCurrentScript_OnCheckedChanged(object sender, EventArgs e)
    {
      Wave.Classes.Passive.Settings.Instance.AppendCurrentScript = this.AppendCurrentScript.IsChecked;
      Wave.Classes.Passive.Settings.Instance.Save();
    }

    private void ClearConversationHistory_OnClicked(object sender, EventArgs e)
    {
      this.aiChat.ClearConversationHistory();
      this.AIChatPanel.Children.RemoveRange(1, this.AIChatPanel.Children.Count - 1);
    }

    private void AIChatScroll_ScrollChanged(object sender, ScrollChangedEventArgs e)
    {
      if (e.ExtentHeightChange <= 0.0)
        return;
      this.AIChatScroll.ScrollToBottom();
    }

    private void CloseInstanceButton_Click(object sender, RoutedEventArgs e)
    {
      this.AnimatePopupOut(this.InstancePopupGrid);
    }

    private async void SelectedProcessButton_Click(object sender, RoutedEventArgs e)
    {
      string str = (await ((IChromiumWebBrowserBase) this.ScriptTabs.SelectedContent).EvaluateScriptAsync("window.getText();", new TimeSpan?(), false)).Result.ToString();
      foreach (InstancePanel child in this.InstanceStack.Children)
        child.Script = str;
      this.AnimatePopupIn(this.InstancePopupGrid);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("/Wave;component/mainwindow.xaml", UriKind.Relative));
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    internal Delegate _CreateDelegate(Type delegateType, string handler)
    {
      return Delegate.CreateDelegate(delegateType, (object) this, handler);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    void IComponentConnector.Connect(int connectionId, object target)
    {
      switch (connectionId)
      {
        case 1:
          this.HomeWindow = (MainWindow) target;
          this.HomeWindow.MouseDown += new MouseButtonEventHandler(this.HomeWindow_MouseDown);
          this.HomeWindow.SizeChanged += new SizeChangedEventHandler(this.HomeWindow_SizeChanged);
          this.HomeWindow.Loaded += new RoutedEventHandler(this.HomeWindow_Loaded);
          this.HomeWindow.SourceInitialized += new EventHandler(this.HomeWindow_SourceInitialized);
          this.HomeWindow.Closing += new CancelEventHandler(this.HomeWindow_Closing);
          break;
        case 5:
          this.InvisiGrid = (Grid) target;
          break;
        case 6:
          this.MainBorder = (Border) target;
          break;
        case 7:
          this.MainGrid = (Grid) target;
          break;
        case 8:
          this.MainContainer = (Grid) target;
          break;
        case 9:
          this.MainBlur = (BlurEffect) target;
          break;
        case 10:
          this.TopGrid = (Grid) target;
          break;
        case 11:
          this.TopSeparator = (Rectangle) target;
          break;
        case 12:
          this.TopPanel = (DockPanel) target;
          break;
        case 13:
          this.CloseButton = (Button) target;
          this.CloseButton.Click += new RoutedEventHandler(this.CloseButton_Click);
          break;
        case 14:
          this.MaximiseButton = (Button) target;
          this.MaximiseButton.Click += new RoutedEventHandler(this.MaximiseButton_Click);
          break;
        case 15:
          this.MinimiseButton = (Button) target;
          this.MinimiseButton.Click += new RoutedEventHandler(this.MinimiseButton_Click);
          break;
        case 16:
          this.BloomIcon = (Image) target;
          break;
        case 17:
          this.SideGrid = (Grid) target;
          break;
        case 18:
          this.SideSeparator = (Rectangle) target;
          break;
        case 19:
          this.SidePanel = (StackPanel) target;
          break;
        case 20:
          this.HomeButton = (TabCheckBox) target;
          break;
        case 21:
          this.EditorButton = (TabCheckBox) target;
          break;
        case 22:
          this.ScriptsButton = (TabCheckBox) target;
          break;
        case 23:
          this.SettingsButton = (TabCheckBox) target;
          break;
        case 24:
          this.TabContainer = (Grid) target;
          break;
        case 25:
          this.HomeTab = (Grid) target;
          break;
        case 26:
          this.EditorTab = (Grid) target;
          break;
        case 27:
          this.AISeparator = (Rectangle) target;
          break;
        case 28:
          this.EditorSeparator = (Rectangle) target;
          break;
        case 29:
          this.EditorButtonPanel = (StackPanel) target;
          break;
        case 30:
          this.SelectedProcessButton = (Button) target;
          this.SelectedProcessButton.Click += new RoutedEventHandler(this.SelectedProcessButton_Click);
          break;
        case 31:
          this.OpenFileButton = (Button) target;
          this.OpenFileButton.Click += new RoutedEventHandler(this.OpenFileButton_Click);
          break;
        case 32:
          this.SaveFileButton = (Button) target;
          this.SaveFileButton.Click += new RoutedEventHandler(this.SaveFileButton_Click);
          break;
        case 33:
          this.ClearButton = (Button) target;
          this.ClearButton.Click += new RoutedEventHandler(this.ClearButton_Click);
          break;
        case 34:
          this.ExecuteButton = (Button) target;
          this.ExecuteButton.Click += new RoutedEventHandler(this.ExecuteButton_Click);
          break;
        case 35:
          this.AIToggleButton = (Button) target;
          this.AIToggleButton.Click += new RoutedEventHandler(this.AIToggleButton_Click);
          break;
        case 36:
          this.AIChatScroll = (ScrollViewer) target;
          this.AIChatScroll.ScrollChanged += new ScrollChangedEventHandler(this.AIChatScroll_ScrollChanged);
          break;
        case 37:
          this.AIChatPanel = (StackPanel) target;
          break;
        case 38:
          this.LoadingAI = (AIBotMessage) target;
          break;
        case 39:
          this.TabSeparator = (Rectangle) target;
          break;
        case 40:
          this.AIInputGrid = (Grid) target;
          break;
        case 41:
          this.AIInputPath = (System.Windows.Shapes.Path) target;
          break;
        case 42:
          this.AIInput = (TextBox) target;
          this.AIInput.GotFocus += new RoutedEventHandler(this.AIInput_GotFocus);
          this.AIInput.KeyDown += new KeyEventHandler(this.AIInput_KeyDown);
          this.AIInput.LostFocus += new RoutedEventHandler(this.AIInput_LostFocus);
          break;
        case 43:
          this.ScriptTabs = (TabControl) target;
          break;
        case 44:
          this.ScriptsTab = (Grid) target;
          break;
        case 45:
          this.SearchQuery = (TextBox) target;
          this.SearchQuery.GotFocus += new RoutedEventHandler(this.SearchQuery_GotFocus);
          this.SearchQuery.KeyDown += new KeyEventHandler(this.SearchQuery_KeyDown);
          this.SearchQuery.LostFocus += new RoutedEventHandler(this.SearchQuery_LostFocus);
          break;
        case 46:
          this.SearchBtn = (Button) target;
          this.SearchBtn.Click += new RoutedEventHandler(this.SearchBtn_Click);
          break;
        case 47:
          this.SearchResultScroll = (ScrollViewer) target;
          break;
        case 48:
          this.SearchResultPanel = (WrapPanel) target;
          break;
        case 49:
          this.NextPageBtn = (Button) target;
          this.NextPageBtn.Click += new RoutedEventHandler(this.NextPageBtn_Click);
          break;
        case 50:
          this.PreviousPageBtn = (Button) target;
          this.PreviousPageBtn.Click += new RoutedEventHandler(this.PreviousPageBtn_Click);
          break;
        case 51:
          this.ScriptBloxCredits = (Button) target;
          this.ScriptBloxCredits.Click += new RoutedEventHandler(this.ScriptBloxCredits_Click);
          break;
        case 52:
          this.CurrentPageBorder = (Border) target;
          break;
        case 53:
          this.CurrentPageLabel = (Label) target;
          break;
        case 54:
          this.SettingsTab = (Grid) target;
          break;
        case 55:
          this.SettingsSeparator = (Rectangle) target;
          break;
        case 56:
          this.SettingsHeaderStack = (StackPanel) target;
          break;
        case 57:
          this.ExecutorHeaderButton = (Button) target;
          break;
        case 58:
          this.EditorHeaderButton = (Button) target;
          break;
        case 59:
          this.AIHeaderButton = (Button) target;
          break;
        case 60:
          this.SettingsScroll = (ScrollViewer) target;
          break;
        case 61:
          this.SettingsStack = (StackPanel) target;
          break;
        case 62:
          this.ExecutorHeader = (Grid) target;
          break;
        case 63:
          this.ExecutorHeaderPath = (System.Windows.Shapes.Path) target;
          break;
        case 64:
          this.ExecutorHeaderLabel = (Label) target;
          break;
        case 65:
          this.MultiInstance = (SettingCheckBox) target;
          break;
        case 66:
          this.AutoExecute = (SettingCheckBox) target;
          break;
        case 67:
          this.SaveTabs = (SettingCheckBox) target;
          break;
        case 68:
          this.TopMost = (SettingCheckBox) target;
          break;
        case 69:
          this.EditorHeader = (Grid) target;
          break;
        case 70:
          this.EditorHeaderPath = (System.Windows.Shapes.Path) target;
          break;
        case 71:
          this.EditorHeaderLabel = (Label) target;
          break;
        case 72:
          this.EditorRefreshRate = (SettingSlider) target;
          break;
        case 73:
          this.EditorTextSize = (SettingSlider) target;
          break;
        case 74:
          this.ShowMinimap = (SettingCheckBox) target;
          break;
        case 75:
          this.ShowInlayHints = (SettingCheckBox) target;
          break;
        case 76:
          this.AIHeader = (Grid) target;
          break;
        case 77:
          this.AIHeaderPath = (System.Windows.Shapes.Path) target;
          break;
        case 78:
          this.AIHeaderLabel = (Label) target;
          break;
        case 79:
          this.UseConversationHistory = (SettingCheckBox) target;
          break;
        case 80:
          this.AppendCurrentScript = (SettingCheckBox) target;
          break;
        case 81:
          this.ClearConversationHistory = (SettingButton) target;
          break;
        case 82:
          this.NotificationBorder = (Border) target;
          break;
        case 83:
          this.NotificationGrid = (Grid) target;
          break;
        case 84:
          this.NotificationContent = (TextBlock) target;
          break;
        case 85:
          this.DurationIndicator = (Border) target;
          break;
        case 86:
          this.CloseNotificationButton = (Button) target;
          this.CloseNotificationButton.Click += new RoutedEventHandler(this.CloseNotificationButton_Click);
          break;
        case 87:
          this.InstancePopupGrid = (Grid) target;
          break;
        case 88:
          this.InstanceBorder = (Border) target;
          break;
        case 89:
          this.InstanceGrid = (Grid) target;
          break;
        case 90:
          this.InstanceTopGrid = (Grid) target;
          break;
        case 91:
          this.InstanceTopSeparator = (Rectangle) target;
          break;
        case 92:
          this.CloseInstanceButton = (Button) target;
          this.CloseInstanceButton.Click += new RoutedEventHandler(this.CloseInstanceButton_Click);
          break;
        case 93:
          this.InstanceTitle = (Label) target;
          break;
        case 94:
          this.InstanceScroll = (ScrollViewer) target;
          this.InstanceScroll.ScrollChanged += new ScrollChangedEventHandler(this.AIChatScroll_ScrollChanged);
          break;
        case 95:
          this.InstanceStack = (StackPanel) target;
          break;
        case 96:
          this.InstanceBackgroundBorder = (Border) target;
          break;
        case 97:
          this.LoginPopupGrid = (Grid) target;
          break;
        case 98:
          this.LoginBorder = (Border) target;
          break;
        case 99:
          this.LoginBackgroundBorder = (Border) target;
          break;
        case 100:
          this.AdBorder = (Border) target;
          this.AdBorder.MouseLeftButtonDown += new MouseButtonEventHandler(this.AdBorder_MouseLeftButtonDown);
          break;
        case 101:
          this.AdGrid = (Grid) target;
          break;
        case 102:
          this.CloseAdButton = (Button) target;
          this.CloseAdButton.Click += new RoutedEventHandler(this.CloseAdButton_Click);
          break;
        default:
          this._contentLoaded = true;
          break;
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    void IStyleConnector.Connect(int connectionId, object target)
    {
      switch (connectionId)
      {
        case 2:
          ((ScrollViewer) target).ScrollChanged += new ScrollChangedEventHandler(this.TabHeaderScroll_ScrollChanged);
          break;
        case 3:
          ((ButtonBase) target).Click += new RoutedEventHandler(this.NewTabButton_Click);
          break;
        case 4:
          ((ButtonBase) target).Click += new RoutedEventHandler(this.CloseTabButton_Click);
          break;
      }
    }

    public struct POINT
    {
      public int x;
      public int y;

      public POINT(int x, int y)
      {
        this.x = x;
        this.y = y;
      }
    }

    public struct MINMAXINFO
    {
      public MainWindow.POINT ptReserved;
      public MainWindow.POINT ptMaxSize;
      public MainWindow.POINT ptMaxPosition;
      public MainWindow.POINT ptMinTrackSize;
      public MainWindow.POINT ptMaxTrackSize;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public class MONITORINFO
    {
      public int cbSize = Marshal.SizeOf(typeof (MainWindow.MONITORINFO));
      public MainWindow.RECT rcMonitor;
      public MainWindow.RECT rcWork;
      public int dwFlags;
    }

    public struct RECT
    {
      public int left;
      public int top;
      public int right;
      public int bottom;
      public static readonly MainWindow.RECT Empty;

      public int Width => Math.Abs(this.right - this.left);

      public int Height => this.bottom - this.top;

      public RECT(int left, int top, int right, int bottom)
      {
        this.left = left;
        this.top = top;
        this.right = right;
        this.bottom = bottom;
      }

      public RECT(MainWindow.RECT rcSrc)
      {
        this.left = rcSrc.left;
        this.top = rcSrc.top;
        this.right = rcSrc.right;
        this.bottom = rcSrc.bottom;
      }

      public bool IsEmpty => this.left >= this.right || this.top >= this.bottom;

      public override string ToString()
      {
        if (this == MainWindow.RECT.Empty)
          return "RECT {Empty}";
        return "RECT { left : " + this.left.ToString() + " / top : " + this.top.ToString() + " / right : " + this.right.ToString() + " / bottom : " + this.bottom.ToString() + " }";
      }

      public override bool Equals(object obj) => obj is Rect && this == (MainWindow.RECT) obj;

      public override int GetHashCode()
      {
        return this.left.GetHashCode() + this.top.GetHashCode() + this.right.GetHashCode() + this.bottom.GetHashCode();
      }

      public static bool operator ==(MainWindow.RECT rect1, MainWindow.RECT rect2)
      {
        return rect1.left == rect2.left && rect1.top == rect2.top && rect1.right == rect2.right && rect1.bottom == rect2.bottom;
      }

      public static bool operator !=(MainWindow.RECT rect1, MainWindow.RECT rect2)
      {
        return !(rect1 == rect2);
      }
    }
  }
}
