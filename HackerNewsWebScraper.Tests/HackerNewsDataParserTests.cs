using System;
using System.Collections.Generic;
using HackerNewsWebScraper.Interfaces;
using HtmlAgilityPack;
using NUnit.Framework;

namespace HackerNewsWebScraper.Tests
{
    [TestFixture]
    public class HackerNewsDataParserTests
    {
        readonly Uri _mockUri = new Uri("http://mockuri.com");
        private IHackerNewsDataProvider _provider;
        private IHackerNewsDataParser _parser;
        private IHackerNewsSettings _settings;
        private HtmlNode _htmlDoc;
        private List<HtmlNode> _titleElements;
        private List<HtmlNode> _subtextElements;


        [SetUp]
        public void Setup()
        {
            _provider = new MockHackerNewsDataProvider();
            _settings = new HackerNewsSettings();
            _parser = new HackerNewsDataParser(_settings);
            _htmlDoc = _provider.GetPageData(_mockUri);
            _titleElements = _provider.GetTitleNodes(_htmlDoc);
            _subtextElements = _provider.GetSubtextNodes(_htmlDoc);
        }

        [Test]
        public void HackerNewsDataParser_GetFirstElementTitle_ReturnsFirstTitle()
        {
            //Arrange

            //Act
            var result = _parser.GetTitle(_titleElements[0]);

            //Assert
            Assert.AreEqual("MacOS System 6, Version 6.0.8: run in browser", result);

        }

        [Test]
        public void HackerNewsDataParser_GetFirstElementUri_ReturnsFirstUri()
        {
            //Arrange

            //Act
            var result = _parser.GetUri(_titleElements[0]);

            //Assert
            Assert.AreEqual("https://archive.org/details/mac_MacOS_6.0.8", result);

        }

        [Test]
        public void HackerNewsDataParser_GetFirstElementAuthor_ReturnsFirstAuthor()
        {
            //Arrange

            //Act
            var result = _parser.GetAuthor(_subtextElements[0]);

            //Assert
            Assert.AreEqual("akeck", result);

        }

        [Test]
        public void HackerNewsDataParser_GetFirstElementNumberOfComments_ReturnsFirstNumberOfComments()
        {
            //Arrange

            //Act
            var result = _parser.GetNumberOfComments(_subtextElements[0]);

            //Assert
            Assert.AreEqual(45, result);

        }

        [Test]
        public void HackerNewsDataParser_GetFirstElementNumberOfPoints_ReturnsFirstNumberOfPoints()
        {
            //Arrange

            //Act
            var result = _parser.GetNumberOfPoints(_subtextElements[0]);

            //Assert
            Assert.AreEqual(154, result);
        }

        [Test]
        public void HackerNewsDataParser_GetFirstElementRank_ReturnsFirstRank()
        {
            //Arrange

            //Act
            var result = _parser.GetRank(_titleElements[0]);

            //Assert
            Assert.AreEqual(31, result);
        }

        [Test]
        public void HackNewsDataParser_GetMissingTitleElement_ReturnsNull()
        {
            //Arrange

            //Act
            var result = _parser.GetTitle(_subtextElements[2]);

            //Assert
            Assert.AreEqual(null, result);

        }

        [Test]
        public void HackNewsDataParser_GetMissingUriElement_ReturnsNull()
        {
            //Arrange

            //Act
            var result = _parser.GetUri(_subtextElements[2]);

            //Assert
            Assert.AreEqual(null, result);

        }

        [Test]
        public void HackNewsDataParser_GetMissingAuthorElement_ReturnsNull()
        {
            //Arrange

            //Act
            var result = _parser.GetAuthor(_subtextElements[1]);

            //Assert
            Assert.AreEqual(null, result);

        }

        [Test]
        public void HackNewsDataParser_GetMissingCommentsElement_ReturnsDefault()
        {
            //Arrange

            //Act
            var result = _parser.GetNumberOfComments(_subtextElements[1]);

            //Assert
            Assert.AreEqual(_settings.CommentsDefault, result);
        }

        [Test]
        public void HackNewsDataParser_GetMissingPointsElement_ReturnsEmptyString()
        {
            //Arrange

            //Act
            var result = _parser.GetNumberOfPoints(_subtextElements[1]);

            //Assert
            Assert.AreEqual(_settings.PointsDefault, result);
        }

        [Test]
        public void HackNewsDataParser_GetMissingRankElement_ReturnsDefault()
        {
            //Arrange

            //Act
            var result = _parser.GetRank(_subtextElements[3]);

            //Assert
            Assert.AreEqual(_settings.RankDefault, result);
        }




    }
}
