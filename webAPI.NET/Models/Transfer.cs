namespace webAPI.Models
{
    public class Transfer
    {
        public Transfer(string from, string to, string content)
        {
            From = from;
            To = to;
            Content = content;
        }

        public string From { get; set; }
        public string To { get; set; }

        public string Content { get; set; }

    }
}
