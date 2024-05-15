using MediatR;
using Microsoft.EntityFrameworkCore;
using MobileParkTask.Core.Api.RequestsPool.Records;
using MobileParkTask.Core.Api.RequestsPool.Records.Read;
using MobileParkTask.Records.Data;
using MobileParkTask.Records.Domain.Models;

namespace MobileParkTask.Records.Api.Handlers.Read;

public class ReadRecordHandler(RecordsDbContext context) : IRequestHandler<ReadRecord, RecordResponse>
{
    public async Task<RecordResponse> Handle(ReadRecord request, CancellationToken ct)
    {
        var set = context.Set<Record>().AsQueryable();
        set = set.Include(nameof(Record.Results));

        var target = await set.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (target is null)
            throw new ArgumentException("Not found");

        return new RecordResponse
        {
            Id = target.Id,
            Keyword = target.Keyword,
            NewsFragment = target.FragmentName,
            Language = target.Language,
            Results = target.Results!.Select(x => new RecordItemResponse { Content = x.Content, VowelsCount = x.VowelsCount }).ToList()
        };
    }
}