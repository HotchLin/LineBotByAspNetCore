using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using LineBotByAspNetCore.ViewModels;
using Newtonsoft.Json;

namespace LineBotByAspNetCore.Utility
{
    public static class LineBot
    {
        public static async Task ReplayMessageAsync(string channelAccessToken, string replyToken, string message)
        {

            HttpClient client = new HttpClient();

            RequestMessage replyMessage = new RequestMessage(replyToken);

            replyMessage.messages.Add(new Message() { type = "text", text = message });

            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + channelAccessToken);

            var jsonReplyMessage = JsonConvert.SerializeObject(replyMessage);

            StringContent stringContent = new StringContent(jsonReplyMessage, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("https://api.line.me/v2/bot/message/reply", stringContent);

            response.EnsureSuccessStatusCode();

        }
    }
}
