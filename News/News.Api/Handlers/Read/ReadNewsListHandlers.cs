using MediatR;
using MobileParkTask.Core.Api.NotificationsPool.News;
using MobileParkTask.Core.Api.RequestsPool.News.Read;
using MobileParkTask.Core.Domain.Constants;
using MobileParkTask.Core.Domain.Enums;
using MobileParkTask.News.Clients;

namespace MobilePark.News.Api.Handlers.Read;

public class ReadNewsListHandler(NewsClient client, IMediator mediator) : IRequestHandler<ReadNewsList, IList<(string Content, int VowelsCount)>>
{
    public async Task<IList<(string Content, int VowelsCount)>> Handle(ReadNewsList request, CancellationToken ct)
    {
        var news = await client.GetNewsListAsync(request.Keyword, request.Language);

        var vowels = request.Language is Languages.RU ? Vowels.RuVowels : Vowels.EnVowels;

        Func<string, int> counter = x => x.ToLower().Count(c => vowels.Contains(c));

        var results = new List<(string Content, int VowelsCount)>();

        switch (request.Fragment)
        {
            case NewsFragments.Title:
                results = news.List.Select(x => (x.Title, counter(x.Title))).ToList();
                break;

            case NewsFragments.Description:
                results = news.List.Select(x => (x.Description, counter(x.Description))).ToList();
                break;

            case NewsFragments.Content:
                results = news.List.Select(x => (x.Content, counter(x.Content))).ToList();
                break;

            default:
                throw new Exception();
        }

        if (results.Any())
            await mediator.Publish(new ReadedNewsList
            {
                Keyword = request.Keyword,
                Fragment = request.Fragment,
                Language = request.Language,
                Results = results
            }, ct);

        return results.OrderByDescending(x => x.VowelsCount).ToList();
    }
}