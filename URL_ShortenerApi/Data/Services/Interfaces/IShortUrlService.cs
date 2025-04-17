namespace URL_ShortenerApi.Data.Services.Interfaces
{
    public interface IShortUrlService
    {
        string LongToShort(string url);
        string ShortToLong(string url);
        int base62ToBase10(string s);
        int convert(char c);
        string base10ToBase62(long n);
    }
}
