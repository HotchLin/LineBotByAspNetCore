namespace LineBotByAspNetCore.ViewModels
{
    public class Event
    {

        public string replyToken { get; set; }
        public string type { get; set; }
        public long timestamp { get; set; }
        public Source source { get; set; }
        public Message message { get; set; }
    }
}