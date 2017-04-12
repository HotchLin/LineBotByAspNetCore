using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LineBotByAspNetCore.ViewModels
{
    public class RequestMessage
    {
        public RequestMessage(string ReplyToken)
        {
            replyToken = ReplyToken;
            messages = new List<Message>();
        }

        public string replyToken { get; set; }
        public List<Message> messages { get; set; }
    }
}
