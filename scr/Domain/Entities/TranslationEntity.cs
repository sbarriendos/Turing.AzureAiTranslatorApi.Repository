using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class TranslationEntity
{
    [Key]
    public required string Guid { get; set; }
    public required DateTime Date { get; set; }
    public required bool IsProcessed { get; set; }
    public required string TargetLanguage { get; set; }
    public required string OriginalText { get; set; }

    public string? SourceLanguage { get; set; }
    public string? TranslatedText { get; set; }
    public float Score { get; set; }
    public string? Error { get; set; }
}
