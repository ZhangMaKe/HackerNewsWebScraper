namespace HackerNewsWebScraper.Interfaces
{
    public interface IHackerNewsStoryItemValidator
    {
        bool IsTitleValid(string title);
        bool IsUriValid(string uri);
        bool IsAuthorValid(string author);
        bool IsRankValid(int rank);
        bool IsCommentsValid(int comment);
        bool IsPointsValid(int points);
    }
}
