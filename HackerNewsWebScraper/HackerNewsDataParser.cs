using System.Linq;
using HackerNewsWebScraper.Interfaces;
using HtmlAgilityPack;
using ScrapySharp.Extensions;

namespace HackerNewsWebScraper
{
    public class HackerNewsDataParser : IHackerNewsDataParser
    {
        private readonly IHackerNewsSettings _settings;

        public HackerNewsDataParser(IHackerNewsSettings settings)
        {
            _settings = settings;
        }
        public HtmlNode GetStorylinkNode(HtmlNode titleNode)
        {
            return titleNode.CssSelect(HackerNewsConstants.StoryCssClass).FirstOrDefault();
        }

        public string GetTitle(HtmlNode titleNode)
        {
            var storylink = GetStorylinkNode(titleNode);

            return storylink?.InnerText;
        }

        public string GetUri(HtmlNode titleNode)
        {
            var storylink = GetStorylinkNode(titleNode);

            if (storylink is null)
            {
                return null;
            }

            var uri = storylink.Attributes[0].Value;

            if (uri.Contains("item?"))
            {
                //uri is a relative uri, add the base uri
                uri = HackerNewsConstants.HackerNewsUri + uri;
            }

            return uri;
        }

        public string GetAuthor(HtmlNode subtextNode)
        {
            var authorNode = subtextNode.CssSelect(HackerNewsConstants.AuthorCssClass).FirstOrDefault();

            return authorNode?.InnerText;
        }

        public int GetNumberOfComments(HtmlNode subtextNode)
        {
            var commentsNode = subtextNode.LastChild.PreviousSibling;

            if (commentsNode is null)
            {
                return _settings.CommentsDefault;
            }

            var commentText = commentsNode.InnerText;

            if (!commentText.Contains("comment"))
            {
                //number of comments not found, return default
                return _settings.CommentsDefault;
            }

            var commentNumberText = commentText.Substring(0, commentText.IndexOf(HackerNewsConstants.CommentSeperatorChar));

            //if the text can be parsed to a number, return the number, otherwise return the default from settings
            return int.TryParse(commentNumberText, out int numberOfComments)
                ? numberOfComments
                : _settings.CommentsDefault;
        }

        public int GetNumberOfPoints(HtmlNode subtextNode)
        {
            var pointsNode = subtextNode.CssSelect(HackerNewsConstants.PointsCssClass).FirstOrDefault();

            if (pointsNode is null)
            {
                //points not found, use default
                return _settings.PointsDefault;
            }

            var pointsText = pointsNode.InnerText;

            //number of points is before the first space in string
            var pointsNumberText = pointsText.Substring(0, pointsText.IndexOf(HackerNewsConstants.PointsSeperatorChar));

            //if the text can be parsed to a number, return the number, otherwise return the default from settings
            return int.TryParse(pointsNumberText, out int numberOfPoints) ? numberOfPoints : _settings.PointsDefault;
        }

        public int GetRank(HtmlNode titleNode)
        {
            var rankNode = titleNode.CssSelect(HackerNewsConstants.RankCssClass).FirstOrDefault();

            if (rankNode is null)
            {
                //rank not found, use default value
                return _settings.RankDefault;
            }

            var rankText = rankNode.InnerText;

            //get the text before the first '.' in rank text
            rankText = rankText.Substring(0, rankText.IndexOf(HackerNewsConstants.RankSeperatorChar));

            //if the text can be parsed to a number, return the number, otherwise return the default from settings
            return int.TryParse(rankText, out int rankNumber) ? rankNumber : _settings.RankDefault;
        }
    }
}
