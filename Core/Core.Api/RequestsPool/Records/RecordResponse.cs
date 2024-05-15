namespace MobileParkTask.Core.Api.RequestsPool.Records;

public class RecordResponse
{
    public int Id { get; set; }

    public string? Keyword { get; set; }

    public string NewsFragment { get; set; }

    public string Language { get; set; }

    public IList<RecordItemResponse>? Results { get; set; }
}

public class RecordItemResponse
{
    public string Content { get; set; }

    public int VowelsCount { get; set; }
}