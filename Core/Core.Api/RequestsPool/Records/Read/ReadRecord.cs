using MediatR;

namespace MobileParkTask.Core.Api.RequestsPool.Records.Read;

public class ReadRecord : IRequest<RecordResponse>
{
    public int Id { get; set; }
}