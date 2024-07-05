// Decompiled with JetBrains decompiler
// Type: Wave.Controls.InstancePanel
// Assembly: Wave, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 33553988-2CCE-4180-BC86-D1681DD7B18E
// Assembly location: D:\Wave_de\provided\WaveTrial\Wave.exe

using Newtonsoft.Json;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Wave.Classes.Implementations;

#nullable disable
namespace Wave.Controls
{
  public partial class InstancePanel : UserControl, IComponentConnector
  {
    public static readonly DependencyProperty UsernameProperty = DependencyProperty.Register(nameof (Username), typeof (string), typeof (InstancePanel), new PropertyMetadata((object) nameof (Username)));
    public static readonly DependencyProperty UserIDProperty = DependencyProperty.Register(nameof (UserID), typeof (double), typeof (InstancePanel), new PropertyMetadata((object) 0.0));
    public static readonly DependencyProperty ProcessIDProperty = DependencyProperty.Register(nameof (ProcessID), typeof (int), typeof (InstancePanel), new PropertyMetadata((object) 0));
    public static readonly DependencyProperty ScriptProperty = DependencyProperty.Register(nameof (Script), typeof (string), typeof (InstancePanel), new PropertyMetadata((object) "print('Not Implemented');"));
    internal InstancePanel InstancePanelControl;
    internal Border InstanceBorder;
    internal VisualStateGroup CommonStates;
    internal VisualState Normal;
    internal VisualState MouseOver;
    internal Grid InstanceGrid;
    internal Border PlayerIcon;
    internal Label UsernameLabel;
    internal Button ExecuteButton;
    internal Label IDLabel;
    internal Button SelectButton;
    private bool _contentLoaded;

    public string Username
    {
      get => (string) this.GetValue(InstancePanel.UsernameProperty);
      set => this.SetValue(InstancePanel.UsernameProperty, (object) value);
    }

    public double UserID
    {
      get => (double) this.GetValue(InstancePanel.UserIDProperty);
      set
      {
        this.SetValue(InstancePanel.UserIDProperty, (object) value);
        this.UpdateThumbnail();
      }
    }

    public int ProcessID
    {
      get => (int) this.GetValue(InstancePanel.ProcessIDProperty);
      set => this.SetValue(InstancePanel.ProcessIDProperty, (object) value);
    }

    public string Script
    {
      get => (string) this.GetValue(InstancePanel.ScriptProperty);
      set => this.SetValue(InstancePanel.ScriptProperty, (object) value);
    }

    public InstancePanel() => this.InitializeComponent();

    private async void UpdateThumbnail()
    {
      Console.WriteLine("Yes");
      using (HttpClient client = new HttpClient())
      {
        try
        {
          ThumbnailResponse thumbnailResponse = JsonConvert.DeserializeObject<ThumbnailResponse>(await (await client.GetAsync("https://thumbnails.roblox.com/v1/users/avatar-headshot?userIds=1&size=48x48&format=Png&isCircular=true")).Content.ReadAsStringAsync());
          BitmapImage bitmapImage = new BitmapImage();
          bitmapImage.BeginInit();
          bitmapImage.UriSource = new Uri(thumbnailResponse.Data[0].imageUrl, UriKind.Absolute);
          bitmapImage.EndInit();
          this.PlayerIcon.Background = (Brush) new ImageBrush()
          {
            ImageSource = (ImageSource) bitmapImage
          };
        }
        catch (Exception ex)
        {
          int num = (int) MessageBox.Show(ex.Message, "Thumbnail Grab Error");
        }
        finally
        {
          client.Dispose();
        }
      }
    }

    private void ExecuteButton_Click(object sender, RoutedEventArgs e)
    {
      Roblox.ExecuteSpecific(new int[1]{ this.ProcessID }, this.Script);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("/Wave;component/controls/instancepanel.xaml", UriKind.Relative));
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    void IComponentConnector.Connect(int connectionId, object target)
    {
      switch (connectionId)
      {
        case 1:
          this.InstancePanelControl = (InstancePanel) target;
          break;
        case 2:
          this.InstanceBorder = (Border) target;
          break;
        case 3:
          this.CommonStates = (VisualStateGroup) target;
          break;
        case 4:
          this.Normal = (VisualState) target;
          break;
        case 5:
          this.MouseOver = (VisualState) target;
          break;
        case 6:
          this.InstanceGrid = (Grid) target;
          break;
        case 7:
          this.PlayerIcon = (Border) target;
          break;
        case 8:
          this.UsernameLabel = (Label) target;
          break;
        case 9:
          this.ExecuteButton = (Button) target;
          this.ExecuteButton.Click += new RoutedEventHandler(this.ExecuteButton_Click);
          break;
        case 10:
          this.IDLabel = (Label) target;
          break;
        case 11:
          this.SelectButton = (Button) target;
          break;
        default:
          this._contentLoaded = true;
          break;
      }
    }
  }
}
