using Newtonsoft.Json.Linq;

namespace HackerNewsWebScraper.Interfaces
{
    public interface IHackerNewsScraper
    {
        IHackerNewsSettings Settings { get; }
        IHackerNewsStoryItemValidator Validator { get; }
        IHackerNewsDataProvider DataProvider { get; }
        IHackerNewsDataParser Parser { get; }
        /// <summary>
        /// Scrape stories and return a JArray
        /// </summary>
        /// <param name="noOfStoriesToGet"></param>
        /// <returns></returns>
        JArray Scrape(int noOfStoriesToGet);
    }
}
