// Decompiled with JetBrains decompiler
// Type: Wave.Controls.TabCheckBox
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
using System.Windows.Media;
using System.Windows.Shapes;
using Wave.Classes.Cosmetic;

#nullable disable
namespace Wave.Controls
{
  public partial class TabCheckBox : UserControl, IComponentConnector
  {
    public static readonly DependencyProperty CanToggleProperty = DependencyProperty.Register(nameof (CanToggle), typeof (bool), typeof (TabCheckBox), new PropertyMetadata((object) true));
    public static readonly DependencyProperty EnabledProperty = DependencyProperty.Register(nameof (Enabled), typeof (bool), typeof (TabCheckBox), new PropertyMetadata((object) false));
    public static readonly DependencyProperty IconProperty = DependencyProperty.Register(nameof (Icon), typeof (string), typeof (TabCheckBox), new PropertyMetadata((object) ""));
    public static readonly DependencyProperty IsIconUniformProperty = DependencyProperty.Register(nameof (IsIconUniform), typeof (bool), typeof (TabCheckBox), new PropertyMetadata((object) false));
    public static readonly DependencyProperty BackgroundSelectedProperty = DependencyProperty.Register(nameof (BackgroundSelected), typeof (Brush), typeof (TabCheckBox), new PropertyMetadata((object) new SolidColorBrush(Color.FromRgb((byte) 29, (byte) 29, (byte) 30))));
    public static readonly DependencyProperty IconSelectedProperty = DependencyProperty.Register(nameof (IconSelected), typeof (Brush), typeof (TabCheckBox), new PropertyMetadata((object) new SolidColorBrush(Colors.White)));
    internal TabCheckBox TabCheckBoxControl;
    internal Grid MainGrid;
    internal Path IconPath;
    internal Rectangle Highlight;
    internal Path IconHighlight;
    private bool _contentLoaded;

    public bool CanToggle
    {
      get => (bool) this.GetValue(TabCheckBox.CanToggleProperty);
      set => this.SetValue(TabCheckBox.CanToggleProperty, (object) value);
    }

    public bool Enabled
    {
      get => (bool) this.GetValue(TabCheckBox.EnabledProperty);
      set
      {
        if (!this.CanToggle)
          return;
        this.SetValue(TabCheckBox.EnabledProperty, (object) value);
        if (value)
          this.OnEnabled((object) this, new EventArgs());
        else
          this.OnDisabled((object) this, new EventArgs());
      }
    }

    public string Icon
    {
      get => (string) this.GetValue(TabCheckBox.IconProperty);
      set => this.SetValue(TabCheckBox.IconProperty, (object) value);
    }

    public bool IsIconUniform
    {
      get => (bool) this.GetValue(TabCheckBox.IsIconUniformProperty);
      set
      {
        this.SetValue(TabCheckBox.IsIconUniformProperty, (object) value);
        this.IconPath.Stretch = value ? Stretch.Uniform : Stretch.Fill;
      }
    }

    public Brush BackgroundSelected
    {
      get => (Brush) this.GetValue(TabCheckBox.BackgroundSelectedProperty);
      set => this.SetValue(TabCheckBox.BackgroundSelectedProperty, (object) value);
    }

    public Brush IconSelected
    {
      get => (Brush) this.GetValue(TabCheckBox.IconSelectedProperty);
      set => this.SetValue(TabCheckBox.IconSelectedProperty, (object) value);
    }

    public event EventHandler OnEnabled;

    public event EventHandler OnDisabled;

    public TabCheckBox()
    {
      this.InitializeComponent();
      this.OnEnabled += new EventHandler(this.TabButton_OnEnabled);
      this.OnDisabled += new EventHandler(this.TabButton_OnDisabled);
    }

    private void TabButton_OnEnabled(object sender, EventArgs e)
    {
      Animation.Animate(new AnimationPropertyBase((object) this.Highlight)
      {
        Property = (object) UIElement.OpacityProperty,
        To = (object) 1
      }, new AnimationPropertyBase((object) this.IconHighlight)
      {
        Property = (object) UIElement.OpacityProperty,
        To = (object) 1
      });
    }

    private void TabButton_OnDisabled(object sender, EventArgs e)
    {
      Animation.Animate(new AnimationPropertyBase((object) this.Highlight)
      {
        Property = (object) UIElement.OpacityProperty,
        To = (object) 0
      }, new AnimationPropertyBase((object) this.IconHighlight)
      {
        Property = (object) UIElement.OpacityProperty,
        To = (object) 0
      });
    }

    private void MainGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
      this.Enabled = !this.Enabled;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("/Wave;component/controls/tabcheckbox.xaml", UriKind.Relative));
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    void IComponentConnector.Connect(int connectionId, object target)
    {
      switch (connectionId)
      {
        case 1:
          this.TabCheckBoxControl = (TabCheckBox) target;
          break;
        case 2:
          this.MainGrid = (Grid) target;
          this.MainGrid.MouseLeftButtonDown += new MouseButtonEventHandler(this.MainGrid_MouseLeftButtonDown);
          break;
        case 3:
          this.IconPath = (Path) target;
          break;
        case 4:
          this.Highlight = (Rectangle) target;
          break;
        case 5:
          this.IconHighlight = (Path) target;
          break;
        default:
          this._contentLoaded = true;
          break;
      }
    }
  }
}
