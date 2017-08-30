using AngleSharp.Parser.Html;
using LakewoodScoop.Scraper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.UserAgent] = "Triple Scoop";
                string html = client.DownloadString("http://www.thelakewoodscoop.com/");

                var parser = new HtmlParser();
                var document = parser.Parse(html);
                var posts = document.QuerySelectorAll(".post");
                var items = new List<Scoop>();
                foreach (var post in posts)
                {
                    var item = new Scoop();
                    var heading = post.QuerySelector("h2");
                    item.Title = heading.TextContent;
                    var par = post.QuerySelector("p");
                    item.Content = par.TextContent;
                    if (post.QuerySelector("img.alignleft") == null)
                    {
                        item.ImageUrl = post.QuerySelector("img.aligncenter").GetAttribute("src");
                    }
                    else
                    {
                        item.ImageUrl = post.QuerySelector("img.alignleft").GetAttribute("src");
                    }
                    item.Date = post.QuerySelector(".postmetadata-top").TextContent;
                    item.Link = heading.QuerySelector("a").GetAttribute("href");
                    if(par.QuerySelector("a.more-link") != null)
                    {
                        item.MoreLink = par.QuerySelector("a.more-link").GetAttribute("href");
                    }
                    items.Add(item);
                }
           
                Console.ReadKey(true);

 

            }

    }
    }
}
