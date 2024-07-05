// Decompiled with JetBrains decompiler
// Type: Wave.Controls.AI.AIBotMessage
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
namespace Wave.Controls.AI
{
  public class AIBotMessage : UserControl, IComponentConnector
  {
    public static readonly DependencyProperty MessageProperty = DependencyProperty.Register(nameof (Message), typeof (string), typeof (AIBotMessage), new PropertyMetadata((object) "~~ No Message Supplied ~~"));
    internal AIBotMessage AIBotMessageControl;
    internal Grid MainGrid;
    internal TextBlock MessageBlock;
    internal Label Title;
    internal Border Sideline;
    private bool _contentLoaded;

    public string Message
    {
      get => (string) this.GetValue(AIBotMessage.MessageProperty);
      set => this.SetValue(AIBotMessage.MessageProperty, (object) value);
    }

    public AIBotMessage() => this.InitializeComponent();

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("/Wave;component/controls/aimessages/aibotmessage.xaml", UriKind.Relative));
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    void IComponentConnector.Connect(int connectionId, object target)
    {
      switch (connectionId)
      {
        case 1:
          this.AIBotMessageControl = (AIBotMessage) target;
          break;
        case 2:
          this.MainGrid = (Grid) target;
          break;
        case 3:
          this.MessageBlock = (TextBlock) target;
          break;
        case 4:
          this.Title = (Label) target;
          break;
        case 5:
          this.Sideline = (Border) target;
          break;
        default:
          this._contentLoaded = true;
          break;
      }
    }
  }
}
