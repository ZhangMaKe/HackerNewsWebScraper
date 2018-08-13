using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using HackerNewsWebScraper.Interfaces;
using HtmlAgilityPack;
using ScrapySharp.Extensions;

namespace HackerNewsWebScraper
{
    public class MockHackerNewsDataProvider : IHackerNewsDataProvider
    {
        public HtmlNode GetPageData(Uri uri)
        {
            var htmlText = File.ReadAllText("TestPage.txt");

            return HtmlNode.CreateNode(htmlText);
        }

        public List<HtmlNode> GetTitleNodes(HtmlNode doc)
        {
            var titleNodes = doc.CssSelect(HackerNewsConstants.TitleItemCssClass).ToList();

            return titleNodes;
        }

        public List<HtmlNode> GetSubtextNodes(HtmlNode doc)
        {
            var subtextNodes = doc.CssSelect(HackerNewsConstants.SubtextItemCssClass).ToList();

            return subtextNodes;
        }
    }
}
