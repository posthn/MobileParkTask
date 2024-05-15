using MediatR;
using Microsoft.AspNetCore.Mvc;
using MobileParkTask.Core.Api.RequestsPool.News.Read;
using MobileParkTask.Core.Domain.Enums;
using MobileParkTask.Core.Web;

namespace MobileParkTask.News.Web.Controllers;

public class NewsController(IMediator mediator) : AppControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetSortedNews(string? keyword, NewsFragments fragment, Languages language)
        => await ProcessRequestAsync(() => mediator.Send(new ReadNewsList
        {
            Keyword = keyword,
            Fragment = fragment,
            Language = language
        }));
}