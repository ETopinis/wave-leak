// Decompiled with JetBrains decompiler
// Type: Wave.Classes.Implementations.AIChat
// Assembly: Wave, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 33553988-2CCE-4180-BC86-D1681DD7B18E
// Assembly location: D:\Wave_de\provided\WaveTrial\Wave.exe

using Azure.AI.OpenAI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Wave.Classes.Passive;

#nullable disable
namespace Wave.Classes.Implementations
{
  internal class AIChat
  {
    private readonly OpenAIClient apiClient;
    private readonly string apiKey = "";
    private readonly List<ChatRequestMessage> conversationHistory = new List<ChatRequestMessage>();
    private readonly string aiContext;

    public AIChat()
    {
      this.apiClient = new OpenAIClient(this.apiKey);
      Assembly executingAssembly = Assembly.GetExecutingAssembly();
      using (Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(((IEnumerable<string>) executingAssembly.GetManifestResourceNames()).Single<string>((Func<string, bool>) (str => str.EndsWith("AIContext.txt")))))
      {
        using (StreamReader streamReader = new StreamReader(manifestResourceStream))
          this.aiContext = streamReader.ReadToEnd();
      }
    }

    public async Task<string> SendNewMessage(string message, string currentTab = null)
    {
      ChatCompletionsOptions completionsOptions = new ChatCompletionsOptions();
      completionsOptions.DeploymentName = "gpt-3.5-turbo-1106";
      completionsOptions.Messages.Add((ChatRequestMessage) new ChatRequestSystemMessage(this.aiContext));
      ChatCompletionsOptions chatCompletionsOptions = completionsOptions;
      this.conversationHistory.Add((ChatRequestMessage) new ChatRequestUserMessage(message));
      for (int index = 0; index < this.conversationHistory.Count; ++index)
      {
        if (index == this.conversationHistory.Count - 1 || Settings.Instance.UseConversationHistory)
        {
          if (index == this.conversationHistory.Count - 1 && currentTab != null)
            chatCompletionsOptions.Messages.Add((ChatRequestMessage) new ChatRequestSystemMessage("The user's currently selected tab content is below:\n\n```lua\n" + currentTab + "\n```"));
          chatCompletionsOptions.Messages.Add(this.conversationHistory[index]);
        }
      }
      string content = (await this.apiClient.GetChatCompletionsAsync(chatCompletionsOptions)).Value.Choices[0].Message.Content;
      this.conversationHistory.Add((ChatRequestMessage) new ChatRequestAssistantMessage(content));
      return content;
    }

    public void ClearConversationHistory()
    {
      this.conversationHistory.RemoveRange(1, this.conversationHistory.Count - 1);
    }
  }
}
