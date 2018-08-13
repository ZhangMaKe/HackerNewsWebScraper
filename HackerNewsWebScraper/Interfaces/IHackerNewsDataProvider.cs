using System;
using System.Collections.Generic;
using HtmlAgilityPack;

namespace HackerNewsWebScraper.Interfaces
{
    public interface IHackerNewsDataProvider
    {
        /// <summary>
        /// Get html from a webpage.
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        HtmlNode GetPageData(Uri uri);

        /// <summary>
        /// Get all the title elements from an html document.
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        List<HtmlNode> GetTitleNodes(HtmlNode doc);

        /// <summary>
        /// Get all the subtext elements from an html document.
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        List<HtmlNode> GetSubtextNodes(HtmlNode doc);
    }

}
