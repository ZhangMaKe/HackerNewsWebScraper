namespace HackerNewsWebScraper.Interfaces
{
    public interface IHackerNewsSettings
    {
        int MaxNumberOfPosts { get; }

        /// <summary>
        /// Default to display if title is invalid or can't be found.
        /// </summary>
        string TitleDefault { get; }
        /// <summary>
        /// Default to display if uri is invalid or can't be found.
        /// </summary>
        string UriDefault { get; }
        /// <summary>
        /// Default to display if author is invalid or can't be found.
        /// </summary>
        string AuthorDefault { get; }
        /// <summary>
        /// Default to display if number of comments is invalid or can't be found.
        /// </summary>
        int CommentsDefault { get; }
        /// <summary>
        /// Default to display if rank is invalid or can't be found.
        /// </summary>
        int RankDefault { get; }

        /// <summary>
        /// Default to display if number of points is invalid or can't be found.
        /// </summary>
        int PointsDefault { get; }
    }
}
