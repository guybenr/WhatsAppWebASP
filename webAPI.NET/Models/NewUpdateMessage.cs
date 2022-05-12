namespace webAPI.NET.Models
{
    public class NewUpdateMessage
    {
        public NewUpdateMessage(string content)
        {
            Content = content;
        }
        public string Content { get; set; }
    }
}
