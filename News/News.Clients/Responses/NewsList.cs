using System.Text.Json.Serialization;

namespace MobileParkTask.News.Clients.Responses;

public class NewsList
{
    [JsonPropertyName("totalResults")]
    public int Count { get; set; }

    [JsonPropertyName("articles")]
    public IList<NewsItem> List { get; set; }
}