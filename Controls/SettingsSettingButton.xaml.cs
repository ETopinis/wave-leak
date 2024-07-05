// Decompiled with JetBrains decompiler
// Type: Wave.Controls.Settings.SettingButton
// Assembly: Wave, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 33553988-2CCE-4180-BC86-D1681DD7B18E
// Assembly location: D:\Wave_de\provided\WaveTrial\Wave.exe

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

#nullable disable
namespace Wave.Controls.Settings
{
  public partial class SettingButton : UserControl, IComponentConnector
  {
    public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(nameof (Title), typeof (string), typeof (SettingButton), new PropertyMetadata((object) nameof (Title)));
    public static readonly DependencyProperty DescriptionProperty = DependencyProperty.Register(nameof (Description), typeof (string), typeof (SettingButton), new PropertyMetadata((object) nameof (Description)));
    public static readonly DependencyProperty ShorthandProperty = DependencyProperty.Register(nameof (Shorthand), typeof (string), typeof (SettingButton), new PropertyMetadata((object) nameof (Shorthand)));
    internal SettingButton SettingButtonControl;
    internal Border MainBorder;
    internal Grid MainGrid;
    internal Label DescriptionLabel;
    internal Label TitleLabel;
    internal Button ClickButton;
    private bool _contentLoaded;

    public string Title
    {
      get => (string) this.GetValue(SettingButton.TitleProperty);
      set => this.SetValue(SettingButton.TitleProperty, (object) value);
    }

    public string Description
    {
      get => (string) this.GetValue(SettingButton.DescriptionProperty);
      set => this.SetValue(SettingButton.DescriptionProperty, (object) value);
    }

    public string Shorthand
    {
      get => (string) this.GetValue(SettingButton.ShorthandProperty);
      set => this.SetValue(SettingButton.ShorthandProperty, (object) value);
    }

    public event EventHandler<EventArgs> OnClicked;

    public SettingButton() => this.InitializeComponent();

    private void ClickButton_Click(object sender, RoutedEventArgs e)
    {
      EventHandler<EventArgs> onClicked = this.OnClicked;
      if (onClicked == null)
        return;
      onClicked((object) this, new EventArgs());
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("/Wave;component/controls/settings/settingbutton.xaml", UriKind.Relative));
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    void IComponentConnector.Connect(int connectionId, object target)
    {
      switch (connectionId)
      {
        case 1:
          this.SettingButtonControl = (SettingButton) target;
          break;
        case 2:
          this.MainBorder = (Border) target;
          break;
        case 3:
          this.MainGrid = (Grid) target;
          break;
        case 4:
          this.DescriptionLabel = (Label) target;
          break;
        case 5:
          this.TitleLabel = (Label) target;
          break;
        case 6:
          this.ClickButton = (Button) target;
          this.ClickButton.Click += new RoutedEventHandler(this.ClickButton_Click);
          break;
        default:
          this._contentLoaded = true;
          break;
      }
    }
  }
}
