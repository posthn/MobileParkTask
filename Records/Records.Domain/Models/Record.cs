namespace MobileParkTask.Records.Domain.Models;

public class Record
{
    public int Id { get; }

    public string? Keyword { get; }

    public string FragmentName { get; }

    public string Language { get; }

    public IList<RecordItem>? Results { get; }

    private Record() { }

    public Record(string? keyword, string fragmentName, string language)
    {
        Keyword = keyword;
        FragmentName = fragmentName;
        Language = language;
    }

    public Record(string? keyword, string fragmentName, string language, List<RecordItem> results) : this(keyword, fragmentName, language)
        => Results = results;
}