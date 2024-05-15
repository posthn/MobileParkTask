namespace MobileParkTask.Records.Domain.Models;

public class RecordItem
{
    public int Id { get; }

    public int RecordId { get; }

    public string Content { get; }

    public int VowelsCount { get; }

    public Record? Record { get; }

    private RecordItem() { }

    public RecordItem(string content, int vowelsCount)
    {
        Content = content;
        VowelsCount = vowelsCount;
    }
}