using System;
using HackerNewsWebScraper.Interfaces;

namespace HackerNewsWebScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            //setup dependancies. this will be updated to use ioc at a latter stage
            var settings = new HackerNewsSettings();
            var provider = new HackerNewsDataProvider();
            var validator = new HackerNewsStoryItemValidator();
            var parser = new HackerNewsDataParser(settings);

            //instanciate the scraper
            var scraper = new HackerNewsScraper(settings, validator, provider, parser);


            //exit and display message exactly 1 arguement is not passed
            if (args.Length != 1)
            {
                Console.WriteLine("program requires 1 arguement: number of posts to display");
                return;
            }

            //exit and display message if arguement is not an integer
            int noOfPosts;
            if (!int.TryParse(args[0], out noOfPosts))
            {
                Console.WriteLine("arguement must be an integer");
                return;
            }

            if (noOfPosts < 0 || noOfPosts > scraper.Settings.MaxNumberOfPosts)
            {
                Console.WriteLine("arguement must be positive integer and no larger than {0}", scraper.Settings.MaxNumberOfPosts);
                return;
            }

            Console.WriteLine("Fetching stories...");
            Console.WriteLine(scraper.Scrape(noOfPosts));         
        }
    }
}
