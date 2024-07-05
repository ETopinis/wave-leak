// Decompiled with JetBrains decompiler
// Type: Wave.Classes.Passive.ScriptObject
// Assembly: Wave, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 33553988-2CCE-4180-BC86-D1681DD7B18E
// Assembly location: D:\Wave_de\provided\WaveTrial\Wave.exe

using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;

#nullable disable
namespace Wave.Classes.Passive
{
  public class ScriptObject
  {
    public string title;
    public string features;
    public string script;
    public string slug;
    public DateTime createdAt;
    public DateTime updatedAt;
    public bool verified;
    public bool key;
    public bool isUniversal;
    public bool isPatched;
    public int views;
    public int likeCount;
    public int dislikeCount;
    public Game game;
    public Owner owner;

    public void Correct()
    {
      this.game?.Correct();
      this.owner?.Correct();
    }

    public async Task GetDetailedObject()
    {
      ScriptObject scriptObject = this;
      using (HttpClient client = new HttpClient())
      {
        foreach (JProperty jproperty in JToken.Parse(await (await client.GetAsync("https://scriptblox.com/api/script/" + scriptObject.slug)).Content.ReadAsStringAsync())[(object) "script"].Cast<JProperty>())
        {
          FieldInfo field = scriptObject.GetType().GetField(jproperty.Name);
          field?.SetValue((object) scriptObject, jproperty.Value.ToObject(field.FieldType));
        }
      }
    }

    public async Task<string> GetScript()
    {
      if (this.script == null)
        await this.GetDetailedObject();
      return this.script;
    }
  }
}
