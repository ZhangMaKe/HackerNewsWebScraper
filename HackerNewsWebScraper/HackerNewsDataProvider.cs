using System;
using System.Collections.Generic;
using System.Linq;
using HackerNewsWebScraper.Interfaces;
using HtmlAgilityPack;
using ScrapySharp.Extensions;
using ScrapySharp.Network;

namespace HackerNewsWebScraper
{
    public class HackerNewsDataProvider : IHackerNewsDataProvider
    {
        public ScrapingBrowser Browser { get; }

        public HackerNewsDataProvider()
        {
            Browser = new ScrapingBrowser();
        }

        public HtmlNode GetPageData(Uri uri)
        {
            return Browser.NavigateToPage(uri).Html;
        }

        public List<HtmlNode> GetTitleNodes(HtmlNode doc)
        {
            return doc.CssSelect(HackerNewsConstants.TitleItemCssClass).ToList();
        }

        public List<HtmlNode> GetSubtextNodes(HtmlNode doc)
        {
            return doc.CssSelect(HackerNewsConstants.SubtextItemCssClass).ToList();
        }
  
    }
}
