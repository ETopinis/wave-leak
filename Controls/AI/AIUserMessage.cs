// Decompiled with JetBrains decompiler
// Type: Wave.Controls.AI.AIUserMessage
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
  public class AIUserMessage : UserControl, IComponentConnector
  {
    public static readonly DependencyProperty UsernameProperty = DependencyProperty.Register(nameof (Username), typeof (string), typeof (AIUserMessage), new PropertyMetadata((object) "Kieran"));
    public static readonly DependencyProperty MessageProperty = DependencyProperty.Register(nameof (Message), typeof (string), typeof (AIUserMessage), new PropertyMetadata((object) "~~ No Message Supplied ~~"));
    internal AIUserMessage AIUserMessageControl;
    internal Grid MainGrid;
    internal TextBlock MessageBlock;
    internal Label Title;
    internal Border Sideline;
    private bool _contentLoaded;

    public string Username
    {
      get => (string) this.GetValue(AIUserMessage.UsernameProperty);
      set => this.SetValue(AIUserMessage.UsernameProperty, (object) value);
    }

    public string Message
    {
      get => (string) this.GetValue(AIUserMessage.MessageProperty);
      set => this.SetValue(AIUserMessage.MessageProperty, (object) value);
    }

    public AIUserMessage() => this.InitializeComponent();

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("/Wave;component/controls/aimessages/aiusermessage.xaml", UriKind.Relative));
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    void IComponentConnector.Connect(int connectionId, object target)
    {
      switch (connectionId)
      {
        case 1:
          this.AIUserMessageControl = (AIUserMessage) target;
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
