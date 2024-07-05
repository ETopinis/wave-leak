// Decompiled with JetBrains decompiler
// Type: Wave.Controls.Settings.SettingCheckBox
// Assembly: Wave, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 33553988-2CCE-4180-BC86-D1681DD7B18E
// Assembly location: D:\Wave_de\provided\WaveTrial\Wave.exe

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Shapes;
using Wave.Classes.Cosmetic;

#nullable disable
namespace Wave.Controls.Settings
{
  public partial class SettingCheckBox : UserControl, IComponentConnector
  {
    public static readonly DependencyProperty IsCheckedProperty = DependencyProperty.Register(nameof (IsChecked), typeof (bool), typeof (SettingCheckBox), new PropertyMetadata((object) false));
    public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(nameof (Title), typeof (string), typeof (SettingCheckBox), new PropertyMetadata((object) nameof (Title)));
    public static readonly DependencyProperty DescriptionProperty = DependencyProperty.Register(nameof (Description), typeof (string), typeof (SettingCheckBox), new PropertyMetadata((object) nameof (Description)));
    internal SettingCheckBox SettingCheckBoxControl;
    internal Border MainBorder;
    internal Grid MainGrid;
    internal Label DescriptionLabel;
    internal Label TitleLabel;
    internal Border IndicatorBorder;
    internal Path IndicatorPath;
    private bool _contentLoaded;

    public bool IsChecked
    {
      get => (bool) this.GetValue(SettingCheckBox.IsCheckedProperty);
      set
      {
        this.SetValue(SettingCheckBox.IsCheckedProperty, (object) value);
        EventHandler<EventArgs> onCheckedChanged = this.OnCheckedChanged;
        if (onCheckedChanged != null)
          onCheckedChanged((object) this, new EventArgs());
        Animation.Animate(new AnimationPropertyBase((object) this.IndicatorPath)
        {
          Property = (object) UIElement.OpacityProperty,
          To = (object) (value ? 1 : 0)
        });
      }
    }

    public string Title
    {
      get => (string) this.GetValue(SettingCheckBox.TitleProperty);
      set => this.SetValue(SettingCheckBox.TitleProperty, (object) value);
    }

    public string Description
    {
      get => (string) this.GetValue(SettingCheckBox.DescriptionProperty);
      set => this.SetValue(SettingCheckBox.DescriptionProperty, (object) value);
    }

    public event EventHandler<EventArgs> OnCheckedChanged;

    public SettingCheckBox() => this.InitializeComponent();

    private void MainBorder_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
      this.IsChecked = !this.IsChecked;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("/Wave;component/controls/settings/settingcheckbox.xaml", UriKind.Relative));
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    void IComponentConnector.Connect(int connectionId, object target)
    {
      switch (connectionId)
      {
        case 1:
          this.SettingCheckBoxControl = (SettingCheckBox) target;
          break;
        case 2:
          this.MainBorder = (Border) target;
          this.MainBorder.MouseLeftButtonDown += new MouseButtonEventHandler(this.MainBorder_MouseLeftButtonDown);
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
          this.IndicatorBorder = (Border) target;
          break;
        case 7:
          this.IndicatorPath = (Path) target;
          break;
        default:
          this._contentLoaded = true;
          break;
      }
    }
  }
}
