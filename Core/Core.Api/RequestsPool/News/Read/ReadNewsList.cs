using MediatR;
using MobileParkTask.Core.Domain.Enums;

namespace MobileParkTask.Core.Api.RequestsPool.News.Read;

public class ReadNewsList : IRequest<IList<(string Content, int VowelsCount)>>
{
    public string? Keyword { get; set; }

    public NewsFragments Fragment { get; set; }

    public Languages Language { get; set; }
}