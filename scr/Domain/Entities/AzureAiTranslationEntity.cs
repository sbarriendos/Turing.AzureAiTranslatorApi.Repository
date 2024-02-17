using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class AzureAiTranslationEntity
{
    public string? DetectedLanguage { get; set; }
    public float Score { get; set; }
    public string? TranslatedLanguage { get; set; }
    public string? TranslatedText { get; set; }
}
