using MobileParkTask.News.Clients.Responses;
using RestEase;

namespace MobileParkTask.News.Clients.Abstractions;

public interface INewsApi
{
    [Get("/v2/everything")]
    Task<Response<NewsList>> GetNewsAsync([Query("q")] string? keyword, string? language, string apiKey);
}