using Application.DTOs;
using Domain.Models;
using FluentValidation;

namespace Presentation.Validators;
public class TranslatorDTOValidator : AbstractValidator<ToTranslateDTO>
{
    public TranslatorDTOValidator()
    {
        RuleFor(t => t.TargetLanguage).NotEmpty().WithMessage("TargetLanguage is required");
        RuleFor(t => t.Text).NotEmpty().WithMessage("Text is required");
    }
}
