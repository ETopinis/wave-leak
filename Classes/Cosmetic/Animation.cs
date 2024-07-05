// Decompiled with JetBrains decompiler
// Type: Wave.Classes.Cosmetic.Animation
// Assembly: Wave, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 33553988-2CCE-4180-BC86-D1681DD7B18E
// Assembly location: D:\Wave_de\provided\WaveTrial\Wave.exe

using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

#nullable disable
namespace Wave.Classes.Cosmetic
{
  internal class Animation
  {
    public static Storyboard Animate(params AnimationPropertyBase[] propertyBases)
    {
      Storyboard storyboard = new Storyboard();
      foreach (AnimationPropertyBase propertyBase in propertyBases)
      {
        Timeline timeline1 = propertyBase.CreateTimeline();
        // ISSUE: reference to a compiler-generated field
        if (Wave.Classes.Cosmetic.Animation.\u003C\u003Eo__0.\u003C\u003Ep__2 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Wave.Classes.Cosmetic.Animation.\u003C\u003Eo__0.\u003C\u003Ep__2 = CallSite<Action<CallSite, Type, Timeline, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "SetTarget", (IEnumerable<Type>) null, typeof (Wave.Classes.Cosmetic.Animation), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[3]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Action<CallSite, Type, Timeline, object> target1 = Wave.Classes.Cosmetic.Animation.\u003C\u003Eo__0.\u003C\u003Ep__2.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Action<CallSite, Type, Timeline, object>> p2 = Wave.Classes.Cosmetic.Animation.\u003C\u003Eo__0.\u003C\u003Ep__2;
        Type type = typeof (Storyboard);
        Timeline timeline2 = timeline1;
        // ISSUE: reference to a compiler-generated field
        if (Wave.Classes.Cosmetic.Animation.\u003C\u003Eo__0.\u003C\u003Ep__1 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Wave.Classes.Cosmetic.Animation.\u003C\u003Eo__0.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Wave.Classes.Cosmetic.Animation), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target2 = Wave.Classes.Cosmetic.Animation.\u003C\u003Eo__0.\u003C\u003Ep__1.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p1 = Wave.Classes.Cosmetic.Animation.\u003C\u003Eo__0.\u003C\u003Ep__1;
        // ISSUE: reference to a compiler-generated field
        if (Wave.Classes.Cosmetic.Animation.\u003C\u003Eo__0.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Wave.Classes.Cosmetic.Animation.\u003C\u003Eo__0.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof (Wave.Classes.Cosmetic.Animation), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj1 = Wave.Classes.Cosmetic.Animation.\u003C\u003Eo__0.\u003C\u003Ep__0.Target((CallSite) Wave.Classes.Cosmetic.Animation.\u003C\u003Eo__0.\u003C\u003Ep__0, propertyBase.OverrideElement, (object) null);
        object obj2 = target2((CallSite) p1, obj1) ? propertyBase.Element : propertyBase.OverrideElement;
        target1((CallSite) p2, type, timeline2, obj2);
        Timeline element = timeline1;
        // ISSUE: reference to a compiler-generated field
        if (Wave.Classes.Cosmetic.Animation.\u003C\u003Eo__0.\u003C\u003Ep__3 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Wave.Classes.Cosmetic.Animation.\u003C\u003Eo__0.\u003C\u003Ep__3 = CallSite<Func<CallSite, Type, object, PropertyPath>>.Create(Binder.InvokeConstructor(CSharpBinderFlags.None, typeof (Wave.Classes.Cosmetic.Animation), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        PropertyPath path = Wave.Classes.Cosmetic.Animation.\u003C\u003Eo__0.\u003C\u003Ep__3.Target((CallSite) Wave.Classes.Cosmetic.Animation.\u003C\u003Eo__0.\u003C\u003Ep__3, typeof (PropertyPath), propertyBase.Property);
        Storyboard.SetTargetProperty((DependencyObject) element, path);
        storyboard.Children.Add(timeline1);
      }
      Task.Run((Action) (() => Application.Current.Dispatcher.Invoke((Action) (() => storyboard.Begin()))));
      return storyboard;
    }

    internal class Presets
    {
    }
  }
}
