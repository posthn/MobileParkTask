using System.Text.Json.Serialization;

namespace MobileParkTask.News.Clients.Responses;

public class NewsItem
{
    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("content")]
    public string Content { get; set; }
}