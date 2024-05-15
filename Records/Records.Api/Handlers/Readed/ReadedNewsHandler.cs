using MediatR;
using MobileParkTask.Core.Api.NotificationsPool.News;
using MobileParkTask.Records.Data;
using MobileParkTask.Records.Domain.Models;

namespace MobileParkTask.Records.Api.Handlers.Readed;

public class ReadedNewsListHandler(RecordsDbContext context) : INotificationHandler<ReadedNewsList>
{
    public async Task Handle(ReadedNewsList notification, CancellationToken ct)
    {
        var @new = new Record(notification.Keyword, notification.Fragment.ToString(), notification.Language.ToString(), notification.Results
            .Select(x => new RecordItem(x.Content, x.VowelsCount)).ToList());
        context.Add(@new);

        await context.SaveChangesAsync(ct);
    }
}
