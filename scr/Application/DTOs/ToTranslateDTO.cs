using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs;
public class ToTranslateDTO
{
    public required string TargetLanguage { get; set; }
    public required string Text { get; set; }

}
