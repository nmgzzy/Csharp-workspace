using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string rootUrl = @"https://www.sina.com.cn/";
            string pattern = @"(href|HREF|src|SRC)[]*=[]*[""'][^""'#>]+[""']";
            string pattern2 = @"(http).*(?="")";
            Dictionary<string, bool> urls = new Dictionary<string, bool>();
            string pageHtml = getUrl(rootUrl);
            Console.WriteLine("--------网页内容：--------");
            Thread.Sleep(1000);
            Console.WriteLine(pageHtml);
            Regex rx2 = new Regex(pattern2, RegexOptions.IgnoreCase);
            MatchCollection mc = getReMatches(pattern, pageHtml);
            foreach (Match mt in mc)
            {
                Match mt2 = rx2.Match(mt.Value);
                if (mt2.Success)
                {
                    urls.TryAdd(mt2.Value, false);
                }
            }
            Thread.Sleep(500);
            Console.WriteLine("\n");
            Console.WriteLine("--------解析网址：--------");
            Thread.Sleep(500);
            List<string> keys = new List<string>(urls.Keys);
            foreach (var key in keys)
            {
                //getUrl(key);
                urls[key] = true;
                Console.WriteLine(key);
                Thread.Sleep(200);
            }
        }

        static string getUrl(string url)
        {
            try
            {
                WebClient client = new WebClient();
                byte[] pageData = client.DownloadData(url);
                string pageHtml = Encoding.Default.GetString(pageData);
                return pageHtml;
            }
            catch (Exception)
            {
                return "";
            }
            
        }
        static MatchCollection getReMatches(string pattern, string text)
        {
            Regex rx = new Regex(pattern, RegexOptions.IgnoreCase);
            return rx.Matches(text);
        }
    }
}
