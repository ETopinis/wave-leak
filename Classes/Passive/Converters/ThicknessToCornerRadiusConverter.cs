// Decompiled with JetBrains decompiler
// Type: Wave.Classes.Passive.Converters.ThicknessToCornerRadiusConverter
// Assembly: Wave, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 33553988-2CCE-4180-BC86-D1681DD7B18E
// Assembly location: D:\Wave_de\provided\WaveTrial\Wave.exe

using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

#nullable disable
namespace Wave.Classes.Passive.Converters
{
  [ValueConversion(typeof (Thickness), typeof (CornerRadius))]
  public class ThicknessToCornerRadiusConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      Thickness thickness = (Thickness) value;
      return (object) new CornerRadius(thickness.Left, thickness.Top, thickness.Right, thickness.Bottom);
    }

    public object ConvertBack(
      object value,
      Type targetType,
      object parameter,
      CultureInfo culture)
    {
      CornerRadius cornerRadius = (CornerRadius) value;
      return (object) new Thickness(cornerRadius.TopLeft, cornerRadius.TopRight, cornerRadius.BottomRight, cornerRadius.BottomLeft);
    }
  }
}
