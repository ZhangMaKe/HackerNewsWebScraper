using System.IO;
using HackerNewsWebScraper.Interfaces;
using HtmlAgilityPack;
using NUnit.Framework;

namespace HackerNewsWebScraper.Tests
{
    [TestFixture]
    public class HackerNewsDataProviderTests
    {
        private const string TestPage = "TestPage.txt";
        private IHackerNewsDataProvider _dataProvider;
        private string _htmlText;
        private HtmlNode _doc;

        [SetUp]
        public void Setup()
        {
            _dataProvider = new HackerNewsDataProvider();
            _htmlText = File.ReadAllText(TestPage);

            _doc = HtmlNode.CreateNode(_htmlText);
        }

        [Test]
        public void HackerNewsDataProvider_GetTitleNodes_DataContains30Items_30ItemsReturned()
        {
            //Arrange

            //Act
            var titleElements = _dataProvider.GetTitleNodes(_doc);

            //Assert
            Assert.AreEqual(30, titleElements.Count);
        }

        [Test]
        public void HackerNewsDataProvider_GetSubtextNodes_DataContains30Items_30ItemsReturned()
        {
            //Arrange

            //Act
            var subtextElements = _dataProvider.GetSubtextNodes(_doc);

            //Assert
            Assert.AreEqual(30, subtextElements.Count);
        }

    }
}
