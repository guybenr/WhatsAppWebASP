namespace webAPI.Models
{
    public class Invitation
    {
        public Invitation(string from, string to, string server)
        {
            From = from;
            To = to;
            Server = server;
        }

        public string From { get; set; }
        public string To { get; set; }

        public string Server { get; set; }

    }
}
