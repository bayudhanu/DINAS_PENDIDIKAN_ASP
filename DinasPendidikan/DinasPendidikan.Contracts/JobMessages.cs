namespace DinasPendidikan.Contracts;

public record SuratMasukImportJob
{
    public Guid JobId { get; init; } = Guid.NewGuid();
    public string FilePath { get; init; } = string.Empty;
    public string UploaderId { get; init; } = string.Empty;
    public DateTime Timestamp { get; init; } = DateTime.UtcNow;
}

public record SuratMasukImportCompleted
{
    public Guid JobId { get; init; }
    public string Status { get; init; } = "Completed";
    public int ProcessedRecords { get; init; }
    public DateTime Timestamp { get; init; } = DateTime.UtcNow;
}

public record SuratMasukImportFailed
{
    public Guid JobId { get; init; }
    public string Status { get; init; } = "Failed";
    public string Error { get; init; } = string.Empty;
    public DateTime Timestamp { get; init; } = DateTime.UtcNow;
}
