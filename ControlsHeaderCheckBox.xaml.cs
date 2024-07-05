// Decompiled with JetBrains decompiler
// Type: Wave.Controls.HeaderCheckBox
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
  public partial class HeaderCheckBox : UserControl, IComponentConnector
  {
    public static readonly DependencyProperty CanToggleProperty = DependencyProperty.Register(nameof (CanToggle), typeof (bool), typeof (HeaderCheckBox), new PropertyMetadata((object) true));
    public static readonly DependencyProperty EnabledProperty = DependencyProperty.Register(nameof (Enabled), typeof (bool), typeof (HeaderCheckBox), new PropertyMetadata((object) false));
    public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(nameof (Title), typeof (string), typeof (HeaderCheckBox), new PropertyMetadata((object) "Untitled.lua"));
    public static readonly DependencyProperty BackgroundSelectedProperty = DependencyProperty.Register(nameof (BackgroundSelected), typeof (Brush), typeof (HeaderCheckBox), new PropertyMetadata((object) new SolidColorBrush(Color.FromRgb((byte) 29, (byte) 29, (byte) 30))));
    internal HeaderCheckBox HeaderCheckBoxControl;
    internal Grid MainGrid;
    internal Rectangle Highlight;
    internal Label ContentLabel;
    internal Button CloseButton;
    private bool _contentLoaded;

    public bool CanToggle
    {
      get => (bool) this.GetValue(HeaderCheckBox.CanToggleProperty);
      set => this.SetValue(HeaderCheckBox.CanToggleProperty, (object) value);
    }

    public bool Enabled
    {
      get => (bool) this.GetValue(HeaderCheckBox.EnabledProperty);
      set
      {
        if (!this.CanToggle)
          return;
        this.SetValue(HeaderCheckBox.EnabledProperty, (object) value);
        if (value)
          this.OnEnabled((object) this, new EventArgs());
        else
          this.OnDisabled((object) this, new EventArgs());
      }
    }

    public string Title
    {
      get => (string) this.GetValue(HeaderCheckBox.TitleProperty);
      set => this.SetValue(HeaderCheckBox.TitleProperty, (object) value);
    }

    public Brush BackgroundSelected
    {
      get => (Brush) this.GetValue(HeaderCheckBox.BackgroundSelectedProperty);
      set => this.SetValue(HeaderCheckBox.BackgroundSelectedProperty, (object) value);
    }

    public event EventHandler OnEnabled;

    public event EventHandler OnDisabled;

    public event EventHandler OnCloseClick;

    public HeaderCheckBox()
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
      });
    }

    private void TabButton_OnDisabled(object sender, EventArgs e)
    {
      Animation.Animate(new AnimationPropertyBase((object) this.Highlight)
      {
        Property = (object) UIElement.OpacityProperty,
        To = (object) 0
      });
    }

    private void MainGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
      this.Enabled = !this.Enabled;
    }

    private void CloseButton_Click(object sender, RoutedEventArgs e)
    {
      this.OnCloseClick(sender, (EventArgs) e);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("/Wave;component/controls/headercheckbox.xaml", UriKind.Relative));
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    void IComponentConnector.Connect(int connectionId, object target)
    {
      switch (connectionId)
      {
        case 1:
          this.HeaderCheckBoxControl = (HeaderCheckBox) target;
          break;
        case 2:
          this.MainGrid = (Grid) target;
          this.MainGrid.MouseLeftButtonDown += new MouseButtonEventHandler(this.MainGrid_MouseLeftButtonDown);
          break;
        case 3:
          this.Highlight = (Rectangle) target;
          break;
        case 4:
          this.ContentLabel = (Label) target;
          break;
        case 5:
          this.CloseButton = (Button) target;
          this.CloseButton.Click += new RoutedEventHandler(this.CloseButton_Click);
          break;
        default:
          this._contentLoaded = true;
          break;
      }
    }
  }
}
