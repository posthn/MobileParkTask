using MediatR;
using Microsoft.AspNetCore.Mvc;
using MobileParkTask.Core.Api.RequestsPool.Records.Read;
using MobileParkTask.Core.Domain.Enums;
using MobileParkTask.Core.Web;

namespace MobileParkTask.Records.Web.Controllers;

public class RecordsController(IMediator mediator) : AppControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetRecordAsync(int id)
        => await ProcessRequestAsync(() => mediator.Send(new ReadRecord
        {
            Id = id
        }));

    [HttpGet("/list")]
    public async Task<IActionResult> GetRecordListAsync(string? keyword, NewsFragments? fragment, Languages? language)
        => await ProcessRequestAsync(() => mediator.Send(new ReadRecordList
        {
            Keyword = keyword,
            Fragment = fragment,
            Language = language
        }));
}