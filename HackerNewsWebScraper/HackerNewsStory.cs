using Newtonsoft.Json;

namespace HackerNewsWebScraper
{
    public class HackerNewsStory
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("uri")]
        public string Uri { get; set; }
        [JsonProperty("author")]
        public string Author { get; set; }
        [JsonProperty("points")]
        public int Points { get; set; }
        [JsonProperty("comments")]
        public int Comments { get; set; }
        [JsonProperty("rank")]
        public int Rank { get; set; }

        public HackerNewsStory(string title, string uri, string author, int points, int comments, int rank)
        {
            Title = title;
            Uri = uri;
            Author = author;
            Points = points;
            Comments = comments;
            Rank = rank;
        }
    }
}
