using System;
using System.Collections.Generic;
using HackerNewsWebScraper.Interfaces;
using HtmlAgilityPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HackerNewsWebScraper
{
    public class HackerNewsScraper : IHackerNewsScraper
    {
        private List<HtmlNode> _titleNodes;
        private List<HtmlNode> _subtextNodes;
        private List<HackerNewsStory> _hackerNewsStories;
        private readonly IHackerNewsSettings _settings;
        private readonly IHackerNewsStoryItemValidator _validator;
        private readonly IHackerNewsDataProvider _dataProvider;
        private readonly IHackerNewsDataParser _parser;

        public HackerNewsScraper(IHackerNewsSettings settings, IHackerNewsStoryItemValidator validator, 
            IHackerNewsDataProvider dataProvider, IHackerNewsDataParser parser)
        {
            _settings = settings;
            _validator = validator;
            _dataProvider = dataProvider;
            _parser = parser;
        }

        /// <summary>
        /// Scrape the Hacker News website
        /// </summary>
        /// /// <param name="noOfStoriesToGet"></param>
        /// <returns></returns>
        public JArray Scrape(int noOfStoriesToGet)
        {
            _hackerNewsStories = new List<HackerNewsStory>();
            var pageNo = 1;

            GetDataFromPage(pageNo);

            for (int i = 0; _hackerNewsStories.Count < noOfStoriesToGet; i++)
            {
                if (ShouldChangePage(i))
                {
                    pageNo++;
                    GetDataFromPage(pageNo); //get the data for the new page
                    i = 0; //reset index at start of new page
                }

                _hackerNewsStories.Add(GetStoryData(_titleNodes[i], _subtextNodes[i]));
            }

            return JArray.Parse(JsonConvert.SerializeObject(_hackerNewsStories));
        }

        /// <summary>
        /// Get items for a story.
        /// </summary>
        /// <param name="titleItem"></param>
        /// <param name="subtextItem"></param>
        /// <returns></returns>
        private HackerNewsStory GetStoryData(HtmlNode titleItem, HtmlNode subtextItem)
        {
            var title = _parser.GetTitle(titleItem);
            title = _validator.IsTitleValid(title) ? title : _settings.TitleDefault;

            var uri = _parser.GetUri(titleItem);
            uri = _validator.IsUriValid(uri) ? uri : _settings.UriDefault;

            var author = _parser.GetAuthor(subtextItem);
            author = _validator.IsAuthorValid(author) ? author : _settings.AuthorDefault;

            var comments = _parser.GetNumberOfComments(subtextItem);
            comments = _validator.IsCommentsValid(comments) ? comments : _settings.CommentsDefault;

            var points = _parser.GetNumberOfPoints(subtextItem);
            points = _validator.IsPointsValid(points) ? points : _settings.PointsDefault;

            var rank = _parser.GetRank(titleItem);
            rank = _validator.IsRankValid(rank) ? rank : _settings.RankDefault;

            return new HackerNewsStory(title, uri, author, points, comments, rank);
        }

        /// <summary>
        /// Determine if end of page has been reached.
        /// </summary>
        /// <param name="itemNumber"></param>
        /// <returns></returns>
        private bool ShouldChangePage(int itemNumber)
        {
            return itemNumber >= _titleNodes.Count;
        }

        /// <summary>
        /// Get the html document, assign the nodes that will be used.
        /// </summary>
        /// <param name="pageNumber"></param>
        private void GetDataFromPage(int pageNumber)
        {
            var pageData = _dataProvider.GetPageData(new Uri(HackerNewsConstants.HackerNewsUri +
                                                    HackerNewsConstants.QueryString + pageNumber));

            _titleNodes = _dataProvider.GetTitleNodes(pageData);
            _subtextNodes = _dataProvider.GetSubtextNodes(pageData);
        }

    }
}
