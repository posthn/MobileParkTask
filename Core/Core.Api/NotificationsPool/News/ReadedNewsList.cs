using MediatR;
using MobileParkTask.Core.Domain.Enums;

namespace MobileParkTask.Core.Api.NotificationsPool.News;

public class ReadedNewsList : INotification
{
    public string? Keyword { get; set; }

    public NewsFragments Fragment { get; set; }

    public Languages Language { get; set; }

    public IList<(string Content, int VowelsCount)> Results { get; set; }
}