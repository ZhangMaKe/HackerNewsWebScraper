using HtmlAgilityPack;

namespace HackerNewsWebScraper.Interfaces
{
    public interface IHackerNewsDataParser
    {
        /// <summary>
        /// Get Title from title element.
        /// </summary>
        /// <param name="titleNode"></param>
        /// <returns></returns>
        string GetTitle(HtmlNode titleNode);
        /// <summary>
        /// Get Uri from title element.
        /// </summary>
        /// <param name="titleNode"></param>
        /// <returns></returns>
        string GetUri(HtmlNode titleNode);
        /// <summary>
        /// Get Author from subtext element.
        /// </summary>
        /// <param name="subtextNode"></param>
        /// <returns></returns>
        string GetAuthor(HtmlNode subtextNode);
        /// <summary>
        /// Get Number of Comments from subtext element.
        /// </summary>
        /// <param name="subtextNode"></param>
        /// <returns></returns>
        int GetNumberOfComments(HtmlNode subtextNode);
        /// <summary>
        /// Get Number of Points from subtext element.
        /// </summary>
        /// <param name="subtextNode"></param>
        /// <returns></returns>
        int GetNumberOfPoints(HtmlNode subtextNode);
        /// <summary>
        /// Get Rank from title element.
        /// </summary>
        /// <param name="titleNode"></param>
        /// <returns></returns>
        int GetRank(HtmlNode titleNode);

        /// <summary>
        /// Get the storylink element from an html block.
        /// </summary>
        /// <param name="titleNode"></param>
        /// <returns></returns>
        HtmlNode GetStorylinkNode(HtmlNode titleNode);
    }
}
