using MediatR;
using MobileParkTask.Core.Domain.Enums;

namespace MobileParkTask.Core.Api.RequestsPool.Records.Read;

public class ReadRecordList : IRequest<IList<RecordResponse>>
{
    public string? Keyword { get; set; }

    public NewsFragments? Fragment { get; set; }

    public Languages? Language { get; set; }
}