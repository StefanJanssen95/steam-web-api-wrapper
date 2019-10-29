namespace EvilRabbot.Database.Models
{
    public class EmojiCounter
    {
        public int Id { get; set; }
        public ulong UserId { get; set; }
        public string Emoji { get; set; }
        public int Count { get; set; }
    }
}