using HackerNewsWebScraper.Interfaces;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace HackerNewsWebScraper.Tests
{
    [TestFixture]
    public class HackerNewsScraperTests
    {
        private IHackerNewsScraper _scraper;
        private IHackerNewsStoryItemValidator _validator;
        private IHackerNewsSettings _settings;
        private IHackerNewsDataProvider _provider;
        private IHackerNewsDataParser _parser;

        [SetUp]
        public void Setup()
        {
            _settings = new HackerNewsSettings();
            _validator = new HackerNewsStoryItemValidator();
            _provider = new MockHackerNewsDataProvider();
            _parser = new HackerNewsDataParser(_settings);

            _scraper = new HackerNewsScraper(_settings, _validator, _provider, _parser);
            
        }
        [Test]
        public void HackerNewsScraper_Scrape_Settings_NumberOfPostsIs10_ArrayLengthReturnedIs10()
        {
            //Arrange
            const int noOfStoriesToGet = 10;

            //Act
            var results = _scraper.Scrape(noOfStoriesToGet);

            //Assert
            Assert.AreEqual(noOfStoriesToGet, results.Count);
        }
        
        [Test]
        public void HackerNewsScraper_Scrape_ReturnsJArray()
        {
            //Arrange
            const int noOfStoriesToGet = 10;

            //Act
            var results = _scraper.Scrape(noOfStoriesToGet);

            //Assert
            Assert.AreEqual(typeof(JArray), results.GetType());

        }
    }
}
