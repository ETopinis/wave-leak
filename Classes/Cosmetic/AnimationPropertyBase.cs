// Decompiled with JetBrains decompiler
// Type: Wave.Classes.Cosmetic.AnimationPropertyBase
// Assembly: Wave, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 33553988-2CCE-4180-BC86-D1681DD7B18E
// Assembly location: D:\Wave_de\provided\WaveTrial\Wave.exe

using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media.Animation;

#nullable disable
namespace Wave.Classes.Cosmetic
{
  internal class AnimationPropertyBase
  {
    internal object Element;
    internal object OverrideElement;
    public object Property;
    public object From;
    public object To;
    public bool DisableEasing;
    public IEasingFunction EasingFunction = (IEasingFunction) new QuarticEase();
    public Duration Duration = (Duration) TimeSpan.FromSeconds(0.4);

    public AnimationPropertyBase(object element) => this.Element = element;

    public AnimationPropertyBase(object element, object overrideElement)
    {
      this.Element = element;
      this.OverrideElement = overrideElement;
    }

    public Timeline CreateTimeline()
    {
      Timeline timeline1 = (Timeline) null;
      object obj1;
      if (!(this.Property is string))
      {
        // ISSUE: reference to a compiler-generated field
        if (AnimationPropertyBase.\u003C\u003Eo__10.\u003C\u003Ep__1 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AnimationPropertyBase.\u003C\u003Eo__10.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.GetMember(CSharpBinderFlags.None, "Name", typeof (AnimationPropertyBase), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, object> target = AnimationPropertyBase.\u003C\u003Eo__10.\u003C\u003Ep__1.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, object>> p1 = AnimationPropertyBase.\u003C\u003Eo__10.\u003C\u003Ep__1;
        // ISSUE: reference to a compiler-generated field
        if (AnimationPropertyBase.\u003C\u003Eo__10.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AnimationPropertyBase.\u003C\u003Eo__10.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.GetMember(CSharpBinderFlags.None, "PropertyType", typeof (AnimationPropertyBase), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj2 = AnimationPropertyBase.\u003C\u003Eo__10.\u003C\u003Ep__0.Target((CallSite) AnimationPropertyBase.\u003C\u003Eo__10.\u003C\u003Ep__0, this.Property);
        obj1 = target((CallSite) p1, obj2);
      }
      else
        obj1 = this.Property;
      if (obj1 is string str)
      {
        switch (str)
        {
          case "Double":
            timeline1 = (Timeline) new DoubleAnimation();
            break;
          case "Thickness":
            timeline1 = (Timeline) new ThicknessAnimation();
            break;
          default:
            if (str.Contains("Color"))
            {
              timeline1 = (Timeline) new ColorAnimation();
              break;
            }
            break;
        }
      }
      // ISSUE: reference to a compiler-generated field
      if (AnimationPropertyBase.\u003C\u003Eo__10.\u003C\u003Ep__6 == null)
      {
        // ISSUE: reference to a compiler-generated field
        AnimationPropertyBase.\u003C\u003Eo__10.\u003C\u003Ep__6 = CallSite<Action<CallSite, PropertyInfo, Timeline, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "SetValue", (IEnumerable<Type>) null, typeof (AnimationPropertyBase), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[3]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      Action<CallSite, PropertyInfo, Timeline, object> target1 = AnimationPropertyBase.\u003C\u003Eo__10.\u003C\u003Ep__6.Target;
      // ISSUE: reference to a compiler-generated field
      CallSite<Action<CallSite, PropertyInfo, Timeline, object>> p6 = AnimationPropertyBase.\u003C\u003Eo__10.\u003C\u003Ep__6;
      PropertyInfo property1 = timeline1.GetType().GetProperty("From");
      Timeline timeline2 = timeline1;
      object obj3;
      if (this.From != null)
      {
        obj3 = this.From;
      }
      else
      {
        // ISSUE: reference to a compiler-generated field
        if (AnimationPropertyBase.\u003C\u003Eo__10.\u003C\u003Ep__5 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AnimationPropertyBase.\u003C\u003Eo__10.\u003C\u003Ep__5 = CallSite<Func<CallSite, object, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.InvokeMember(CSharpBinderFlags.None, "GetValue", (IEnumerable<Type>) null, typeof (AnimationPropertyBase), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, object, object> target2 = AnimationPropertyBase.\u003C\u003Eo__10.\u003C\u003Ep__5.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, object, object>> p5 = AnimationPropertyBase.\u003C\u003Eo__10.\u003C\u003Ep__5;
        // ISSUE: reference to a compiler-generated field
        if (AnimationPropertyBase.\u003C\u003Eo__10.\u003C\u003Ep__4 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AnimationPropertyBase.\u003C\u003Eo__10.\u003C\u003Ep__4 = CallSite<Func<CallSite, object, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.InvokeMember(CSharpBinderFlags.None, "GetProperty", (IEnumerable<Type>) null, typeof (AnimationPropertyBase), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, object, object> target3 = AnimationPropertyBase.\u003C\u003Eo__10.\u003C\u003Ep__4.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, object, object>> p4 = AnimationPropertyBase.\u003C\u003Eo__10.\u003C\u003Ep__4;
        // ISSUE: reference to a compiler-generated field
        if (AnimationPropertyBase.\u003C\u003Eo__10.\u003C\u003Ep__3 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AnimationPropertyBase.\u003C\u003Eo__10.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.InvokeMember(CSharpBinderFlags.None, "GetType", (IEnumerable<Type>) null, typeof (AnimationPropertyBase), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj4 = AnimationPropertyBase.\u003C\u003Eo__10.\u003C\u003Ep__3.Target((CallSite) AnimationPropertyBase.\u003C\u003Eo__10.\u003C\u003Ep__3, this.Element);
        object obj5;
        if (!(this.Property is string))
        {
          // ISSUE: reference to a compiler-generated field
          if (AnimationPropertyBase.\u003C\u003Eo__10.\u003C\u003Ep__2 == null)
          {
            // ISSUE: reference to a compiler-generated field
            AnimationPropertyBase.\u003C\u003Eo__10.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.GetMember(CSharpBinderFlags.None, "Name", typeof (AnimationPropertyBase), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          obj5 = AnimationPropertyBase.\u003C\u003Eo__10.\u003C\u003Ep__2.Target((CallSite) AnimationPropertyBase.\u003C\u003Eo__10.\u003C\u003Ep__2, this.Property);
        }
        else
          obj5 = this.Property;
        object obj6 = target3((CallSite) p4, obj4, obj5);
        object element = this.Element;
        obj3 = target2((CallSite) p5, obj6, element);
      }
      target1((CallSite) p6, property1, timeline2, obj3);
      // ISSUE: reference to a compiler-generated field
      if (AnimationPropertyBase.\u003C\u003Eo__10.\u003C\u003Ep__8 == null)
      {
        // ISSUE: reference to a compiler-generated field
        AnimationPropertyBase.\u003C\u003Eo__10.\u003C\u003Ep__8 = CallSite<Action<CallSite, PropertyInfo, Timeline, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "SetValue", (IEnumerable<Type>) null, typeof (AnimationPropertyBase), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[3]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      Action<CallSite, PropertyInfo, Timeline, object> target4 = AnimationPropertyBase.\u003C\u003Eo__10.\u003C\u003Ep__8.Target;
      // ISSUE: reference to a compiler-generated field
      CallSite<Action<CallSite, PropertyInfo, Timeline, object>> p8 = AnimationPropertyBase.\u003C\u003Eo__10.\u003C\u003Ep__8;
      PropertyInfo property2 = timeline1.GetType().GetProperty("To");
      Timeline timeline3 = timeline1;
      object obj7;
      if (!(this.To is int))
      {
        obj7 = this.To;
      }
      else
      {
        // ISSUE: reference to a compiler-generated field
        if (AnimationPropertyBase.\u003C\u003Eo__10.\u003C\u003Ep__7 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AnimationPropertyBase.\u003C\u003Eo__10.\u003C\u003Ep__7 = CallSite<Func<CallSite, Type, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.InvokeMember(CSharpBinderFlags.None, "ToDouble", (IEnumerable<Type>) null, typeof (AnimationPropertyBase), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        obj7 = AnimationPropertyBase.\u003C\u003Eo__10.\u003C\u003Ep__7.Target((CallSite) AnimationPropertyBase.\u003C\u003Eo__10.\u003C\u003Ep__7, typeof (Convert), this.To);
      }
      target4((CallSite) p8, property2, timeline3, obj7);
      if (!this.DisableEasing)
        timeline1.GetType().GetProperty("EasingFunction").SetValue((object) timeline1, (object) this.EasingFunction);
      timeline1.Duration = this.Duration;
      return timeline1;
    }
  }
}
