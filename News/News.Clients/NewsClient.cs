using MobileParkTask.Core.Domain.Enums;
using MobileParkTask.News.Clients.Abstractions;
using MobileParkTask.News.Clients.Responses;
using RestEase;

namespace MobileParkTask.News.Clients;

public class NewsClient
{
    private readonly string _apiKey;
    private readonly HttpClient _clientBase;

    public NewsClient(string apiKey, string newsUrl)
    {
        _apiKey = apiKey;

        _clientBase = new HttpClient
        {
            BaseAddress = new Uri(newsUrl),
            Timeout = TimeSpan.FromSeconds(15)
        };
    }

    public async Task<NewsList> GetNewsListAsync(string? keyword, Languages language)
    {
        var newsApi = RestClient.For<INewsApi>(_clientBase);

        using var newsResponse = await newsApi.GetNewsAsync(keyword, language is Languages.RU ? "ru" : "en", _apiKey);
        if (newsResponse.ResponseMessage.IsSuccessStatusCode is false)
            throw new Exception(newsResponse.ResponseMessage.StatusCode.ToString());

        return newsResponse.GetContent();
    }
}