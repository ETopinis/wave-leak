// Decompiled with JetBrains decompiler
// Type: Wave.Classes.Passive.Extensions
// Assembly: Wave, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 33553988-2CCE-4180-BC86-D1681DD7B18E
// Assembly location: D:\Wave_de\provided\WaveTrial\Wave.exe

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

#nullable disable
namespace Wave.Classes.Passive
{
  internal static class Extensions
  {
    internal static DependencyObject FindChild(
      this DependencyObject parent,
      string childName,
      Type childType)
    {
      DependencyObject child1 = (DependencyObject) null;
      if (parent != null)
      {
        int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
        for (int childIndex = 0; childIndex < childrenCount; ++childIndex)
        {
          DependencyObject child2 = VisualTreeHelper.GetChild(parent, childIndex);
          if (child2.GetType() != childType)
          {
            child1 = child2.FindChild(childName, childType);
            if (child1 != null)
              break;
          }
          else if (!string.IsNullOrEmpty(childName))
          {
            if (child2 is FrameworkElement frameworkElement && frameworkElement.Name == childName)
            {
              child1 = child2;
              break;
            }
          }
          else
          {
            child1 = child2;
            break;
          }
        }
      }
      return child1;
    }

    internal static void SetUriSource(this Image image, string link)
    {
      BitmapImage bitmapImage = new BitmapImage();
      bitmapImage.BeginInit();
      bitmapImage.UriSource = new Uri(link, UriKind.Absolute);
      bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
      bitmapImage.EndInit();
      image.Source = (ImageSource) bitmapImage;
    }

    internal static string GetRandomItem(this string[] strings)
    {
      return strings[new Random().Next(strings.Length)];
    }
  }
}
