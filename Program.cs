using System;
using System.Data.Entity.Core;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string html;
            var client = new WebClient();
            html = client.DownloadString("https://www.tradingview.com/markets/stocks-usa/market-movers-" +
                "most-volatile/"
               //"active/"
               );
            string pattern = @"""\w+\\"",\d+.\d+,\d+.\d+,\d+.\d+,\d+.\d+,\d+.\d+,\d+.\d+";
            Regex rgx = new Regex(pattern);
            List<string> stocks = new List<string>();
            if (rgx.IsMatch(html))
            {
               
                foreach (Match match in rgx.Matches(html))
                {
                    string[] matches = match.Value.Split(',');
                    if (//Convert.ToDouble(matches[1]) < 6 && 
                        Convert.ToDouble(matches[2]) > 20
                        //&& Convert.ToDouble(matches[2])<20
                        && Convert.ToDouble(matches[5])>1000000
                        )
                    {
                        stocks.Add(matches[0]);
                        Console.Write(match.Value + "\n");
                    }
                   /* else if(Convert.ToDouble(matches[2]) > 0&& Convert.ToDouble(matches[3]) > 5000000)
                    {
                        stocks.Add(matches[0]);
                        Console.Write(match.Value + "\n");
                    }*/
                }
               // Console.Write(Regex.Matches(html, pattern)[1].Value);
            }
            string @base = "https://www.tradingview.com/symbols/NASDAQ-";
            string url;
            string stckptn = @"\b\w+\b";
            Regex stck = new Regex(stckptn);
          /*  foreach(string nm in stocks)
            {
                url = @base + stck.Match(nm);
                System.Diagnostics.Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", url);
            }*/
        }
    }
}