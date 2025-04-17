using Microsoft.Extensions.Primitives;
using System.Text;
using URL_ShortenerApi.Data.Services.Interfaces;

namespace URL_ShortenerApi.Data.Services.Implementation
{
    public class ShortUrlService : IShortUrlService
    {
        Dictionary<string, long> ltos;
        Dictionary<long ,string> stol;
        static long COUNTER = 100000000000;
        string elements;
        public ShortUrlService()
        {
            ltos = new Dictionary<string, long>();
            stol = new Dictionary<long, string>();
            COUNTER = 100000000000;
            elements = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        }
        public string LongToShort(string url)
        {
            string shorturl = base10ToBase62(COUNTER);
            ltos.Add(url, COUNTER);
            stol.Add(COUNTER, url);
            COUNTER++;
            return "http://tiny.url/" + shorturl;
        }
        public string ShortToLong(string url)
        {
            url = url.Substring("http://tiny.url/".Length);
            int n = base62ToBase10(url);
            return stol[n];
        }
        public int base62ToBase10(string s)
        {
            int n = 0;
            for (int i = 0; i < s.Length; i++)
            {
                n = n * 62 + convert(s[i]);
            }
            return n; // counter value of this url
        }
        public int convert(char c)
        {
            if (c >= '0' && c <= '9')
                return c - '0';
            if (c >= 'a' && c <= 'z')
            {
                return c - 'a' + 10;
            }
            if (c >= 'A' && c <= 'Z')
            {
                return c - 'A' + 36;
            }
            return -1;
        }
        public string base10ToBase62(long n)
        {
            StringBuilder sb = new StringBuilder();
            while (n != 0)
            {
                sb.Append(elements[(int)n % 62]);
                n /= 62;
            }
            while (sb.Length != 7)
            {
                sb.Append('0');
            }
            return sb.ToString();
        }
    }
}