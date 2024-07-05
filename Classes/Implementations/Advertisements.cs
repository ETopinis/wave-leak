// Decompiled with JetBrains decompiler
// Type: Wave.Classes.Implementations.Advertisements
// Assembly: Wave, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 33553988-2CCE-4180-BC86-D1681DD7B18E
// Assembly location: D:\Wave_de\provided\WaveTrial\Wave.exe

using System;

#nullable disable
namespace Wave.Classes.Implementations
{
  internal class Advertisements
  {
    private static readonly Advertisement[] ads = new Advertisement[4]
    {
      new Advertisement()
      {
        localImageLink = "/Assets/Images/Ads/WavePremiumAd.png",
        redirectLink = "https://getwave.gg"
      },
      new Advertisement()
      {
        localImageLink = "/Assets/Images/Ads/LVAd.jpg",
        redirectLink = "https://publisher.linkvertise.com/ac/1138912"
      },
      new Advertisement()
      {
        localImageLink = "/Assets/Images/Ads/WiiHubAd.png",
        redirectLink = "https://discord.gg/wiihub"
      },
      new Advertisement()
      {
        localImageLink = "/Assets/Images/Ads/ArgonAd.png",
        redirectLink = "https://discord.gg/kMpdtwFh"
      }
    };

    public static Advertisement GetAdvertisement()
    {
      return Advertisements.ads[new Random().Next(Advertisements.ads.Length)];
    }
  }
}
