using Application.DTOs;
using Domain.Entities;
using MediatR;

namespace Application.Translator.Commands;
public class TranslateCommand : IRequest<ToTranslateResponseDTO>
{
    public required ToTranslateDTO TranslatorDTO { get; set; }
}
