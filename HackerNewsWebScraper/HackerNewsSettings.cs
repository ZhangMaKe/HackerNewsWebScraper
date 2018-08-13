using System;
using System.IO;
using HackerNewsWebScraper.Interfaces;
using Microsoft.Extensions.Configuration;

namespace HackerNewsWebScraper
{
    public class HackerNewsSettings : IHackerNewsSettings
    {
        private readonly IConfiguration _configuration;
        public HackerNewsSettings()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            _configuration = builder.Build();
        }
        public int MaxNumberOfPosts => Convert.ToInt32(_configuration["maxNumberOfPosts"]);
        public string TitleDefault => _configuration["titleDefault"];
        public string UriDefault => _configuration["uriDefault"];
        public string AuthorDefault => _configuration["authorDefault"];
        public int CommentsDefault => Convert.ToInt32(_configuration["commentsDefault"]);
        public int RankDefault => Convert.ToInt32(_configuration["rankDefault"]);
        public int PointsDefault => Convert.ToInt32(_configuration["pointsDefault"]);
    }
}
