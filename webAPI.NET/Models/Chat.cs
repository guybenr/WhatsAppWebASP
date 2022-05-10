namespace webAPI.Models
{
    public class Chat
    {
        public Chat(string user1, string user2)
        {
            User1 = user1;
            User2 = user2;
            M
        }

        public string User1 { get; set; }

        public string User2 { get; set; }

        List<Message> Messages { get; set; }
    }
}