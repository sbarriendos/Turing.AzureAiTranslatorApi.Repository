using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs;
public class TranslationDTO
{
    public required string TargetLanguage { get; set; }
    public string? SourceLanguage { get; set; }
    public string? TranslatedText { get; set; }

}
