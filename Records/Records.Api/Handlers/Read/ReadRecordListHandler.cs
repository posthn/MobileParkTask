using System.Linq.Expressions;
using MediatR;
using MobileParkTask.Core.Api.RequestsPool.Records;
using MobileParkTask.Core.Api.RequestsPool.Records.Read;
using MobileParkTask.Records.Data;
using MobileParkTask.Records.Domain.Models;

namespace MobileParkTask.Records.Api.Handlers.Read;

public class ReadRecordListHandler(RecordsDbContext context) : IRequestHandler<ReadRecordList, IList<RecordResponse>>
{
    public async Task<IList<RecordResponse>> Handle(ReadRecordList request, CancellationToken ct)
    {
        var filters = new List<Expression<Func<Record, bool>>>();

        if (string.IsNullOrEmpty(request.Keyword) is false)
            filters.Add(x => x.Keyword == request.Keyword);
        if (request.Fragment is not null)
            filters.Add(x => x.FragmentName == request.Fragment.ToString());
        if (request.Language is not null)
            filters.Add(x => x.Language == request.Language.ToString());

        var set = context.Set<Record>().AsQueryable();

        if (filters.Any())
            foreach (var filter in filters)
                set = await Task.Run(() => set.Where(filter), ct);

        if (set is null || set.Any() is false)
            throw new NullReferenceException("Not found");

        return set.Select(x => new RecordResponse
        {
            Id = x.Id,
            Keyword = x.Keyword,
            NewsFragment = x.FragmentName,
            Language = x.Language
        }).ToList();
    }
}