namespace Learning_Project.DTO
{
    public class ChatMessage
    {
        public string UserName { get; set; }
        public string Content { get; set; }

        public DateTimeOffset TimeStamp { get; set; }
    }
}
