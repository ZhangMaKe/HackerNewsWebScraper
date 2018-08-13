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
        public List<HtmlNode> TitleNodes { get; set; }
        public List<HtmlNode> SubtextNodes { get; set; }
        public List<HackerNewsStory> HackerNewsStories { get; set; }
        public IHackerNewsSettings Settings { get; }
        public IHackerNewsStoryItemValidator Validator { get; }
        public IHackerNewsDataProvider DataProvider { get; }
        public IHackerNewsDataParser Parser { get; }

        public HackerNewsScraper(IHackerNewsSettings settings, IHackerNewsStoryItemValidator validator, 
            IHackerNewsDataProvider dataProvider, IHackerNewsDataParser parser)
        {
            Settings = settings;
            Validator = validator;
            DataProvider = dataProvider;
            Parser = parser;
        }

        /// <summary>
        /// Scrape the Hacker News website
        /// </summary>
        /// /// <param name="noOfStoriesToGet"></param>
        /// <returns></returns>
        public JArray Scrape(int noOfStoriesToGet)
        {
            HackerNewsStories = new List<HackerNewsStory>();
            var pageNo = 1;

            GetDataFromPage(pageNo);

            for (int i = 0; HackerNewsStories.Count < noOfStoriesToGet; i++)
            {
                if (ShouldChangePage(i))
                {
                    pageNo++;
                    GetDataFromPage(pageNo); //get the data for the new page
                    i = 0; //reset index at start of new page
                }

                HackerNewsStories.Add(GetStoryData(TitleNodes[i], SubtextNodes[i]));
            }

            return JArray.Parse(JsonConvert.SerializeObject(HackerNewsStories));
        }

        /// <summary>
        /// Get items for a story.
        /// </summary>
        /// <param name="titleItem"></param>
        /// <param name="subtextItem"></param>
        /// <returns></returns>
        private HackerNewsStory GetStoryData(HtmlNode titleItem, HtmlNode subtextItem)
        {
            var title = Parser.GetTitle(titleItem);
            title = Validator.IsTitleValid(title) ? title : Settings.TitleDefault;

            var uri = Parser.GetUri(titleItem);
            uri = Validator.IsUriValid(uri) ? uri : Settings.UriDefault;

            var author = Parser.GetAuthor(subtextItem);
            author = Validator.IsAuthorValid(author) ? author : Settings.AuthorDefault;

            var comments = Parser.GetNumberOfComments(subtextItem);
            comments = Validator.IsCommentsValid(comments) ? comments : Settings.CommentsDefault;

            var points = Parser.GetNumberOfPoints(subtextItem);
            points = Validator.IsPointsValid(points) ? points : Settings.PointsDefault;

            var rank = Parser.GetRank(titleItem);
            rank = Validator.IsRankValid(rank) ? rank : Settings.RankDefault;

            return new HackerNewsStory(title, uri, author, points, comments, rank);
        }

        /// <summary>
        /// Determine if end of page has been reached.
        /// </summary>
        /// <param name="itemNumber"></param>
        /// <returns></returns>
        private bool ShouldChangePage(int itemNumber)
        {
            return itemNumber >= TitleNodes.Count;
        }

        /// <summary>
        /// Get the html document, assign the nodes that will be used.
        /// </summary>
        /// <param name="pageNumber"></param>
        private void GetDataFromPage(int pageNumber)
        {
            var pageData = DataProvider.GetPageData(new Uri(HackerNewsConstants.HackerNewsUri +
                                                    HackerNewsConstants.QueryString + pageNumber));

            TitleNodes = DataProvider.GetTitleNodes(pageData);
            SubtextNodes = DataProvider.GetSubtextNodes(pageData);
        }

    }
}
