using Newtonsoft.Json.Linq;

namespace HackerNewsWebScraper.Interfaces
{
    public interface IHackerNewsScraper
    {
        /// <summary>
        /// Scrape stories and return a JArray
        /// </summary>
        /// <param name="noOfStoriesToGet"></param>
        /// <returns></returns>
        JArray Scrape(int noOfStoriesToGet);
    }
}
