namespace LineBotByAspNetCore.ViewModels
{
    public class Message
    {
        public string id { get; set; }
        public string type { get; set; }
        public string text { get; set; }
        public string originalContentUrl { get; set; }
        public string previewImageUrl { get; set; }
    }
}