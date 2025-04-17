namespace URL_ShortenerApi.Models
{
    public class ShortenedUrl
    {
        public Guid Id { get; set; }
        public string ShortUrl { get; set; }
        public string LongUrl { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}