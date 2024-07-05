// Decompiled with JetBrains decompiler
// Type: Wave.Controls.ScriptResult
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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Wave.Classes.Passive;

#nullable disable
namespace Wave.Controls
{
  public partial class ScriptResult : UserControl, IComponentConnector
  {
    public ScriptObject scriptObject;
    internal ScriptResult ScriptResultControl;
    internal Border MainBorder;
    internal Grid MainGrid;
    internal Border Icon;
    internal WrapPanel Tags;
    internal Border Universal;
    internal Label UniversalLabel;
    internal Border Key;
    internal Label KeyLabel;
    internal Border Patched;
    internal Label PatchedLabel;
    internal Rectangle Separator;
    internal Button ExecuteButton;
    internal Label Title;
    internal Label Created;
    internal Label Views;
    private bool _contentLoaded;

    public ScriptResult() => this.InitializeComponent();

    public ScriptResult(ScriptObject scriptObj)
    {
      ScriptResult scriptResult = this;
      this.scriptObject = scriptObj;
      scriptObj.Correct();
      this.InitializeComponent();
      ImageBrush background404 = (ImageBrush) this.Icon.Background;
      BitmapImage bitmapImage = new BitmapImage();
      bitmapImage.DownloadFailed += (EventHandler<ExceptionEventArgs>) ((sender, e) => scriptResult.Icon.Background = (Brush) background404);
      bitmapImage.BeginInit();
      bitmapImage.UriSource = new Uri(scriptObj.game.imageUrl, UriKind.Absolute);
      bitmapImage.EndInit();
      this.Icon.Background = (Brush) new ImageBrush()
      {
        ImageSource = (ImageSource) bitmapImage
      };
      this.Title.Content = (object) scriptObj.title;
      this.Created.Content = (object) ("Created: " + scriptObj.createdAt.ToShortDateString());
      this.Views.Content = (object) ("Views: " + scriptObj.views.ToString("#,##0"));
      if (!scriptObj.isPatched)
        this.Patched.Visibility = Visibility.Collapsed;
      if (!scriptObj.isUniversal)
        this.Universal.Visibility = Visibility.Collapsed;
      if (scriptObj.key)
        return;
      this.Key.Visibility = Visibility.Collapsed;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("/Wave;component/controls/scriptresult.xaml", UriKind.Relative));
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    void IComponentConnector.Connect(int connectionId, object target)
    {
      switch (connectionId)
      {
        case 1:
          this.ScriptResultControl = (ScriptResult) target;
          break;
        case 2:
          this.MainBorder = (Border) target;
          break;
        case 3:
          this.MainGrid = (Grid) target;
          break;
        case 4:
          this.Icon = (Border) target;
          break;
        case 5:
          this.Tags = (WrapPanel) target;
          break;
        case 6:
          this.Universal = (Border) target;
          break;
        case 7:
          this.UniversalLabel = (Label) target;
          break;
        case 8:
          this.Key = (Border) target;
          break;
        case 9:
          this.KeyLabel = (Label) target;
          break;
        case 10:
          this.Patched = (Border) target;
          break;
        case 11:
          this.PatchedLabel = (Label) target;
          break;
        case 12:
          this.Separator = (Rectangle) target;
          break;
        case 13:
          this.ExecuteButton = (Button) target;
          break;
        case 14:
          this.Title = (Label) target;
          break;
        case 15:
          this.Created = (Label) target;
          break;
        case 16:
          this.Views = (Label) target;
          break;
        default:
          this._contentLoaded = true;
          break;
      }
    }
  }
}
