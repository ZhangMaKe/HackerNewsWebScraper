using System;
using HackerNewsWebScraper.Interfaces;

namespace HackerNewsWebScraper
{
    public class HackerNewsStoryItemValidator : IHackerNewsStoryItemValidator
    {
        public bool IsTitleValid(string title)
        {
            return !string.IsNullOrEmpty(title) && title.Length <= 256;
        }

        public bool IsUriValid(string uri)
        {
            return !string.IsNullOrEmpty(uri) && Uri.IsWellFormedUriString(uri, UriKind.Absolute);
        }

        public bool IsAuthorValid(string author)
        {
            return !string.IsNullOrEmpty(author) && author.Length <= 256;
        }

        public bool IsRankValid(int rank)
        {
            return rank >= 0;
        }

        public bool IsCommentsValid(int comment)
        {
            return comment >= 0;
        }

        public bool IsPointsValid(int points)
        {
            return points >= 0;
        }
    }
}
