using Application.Abstractions;
using Application.DTOs;
using Application.Translator.Commands;
using Domain.Entities;
using Domain.Models;
using MediatR;

namespace Application.Translator.CommandHandlers;
public class TranslateCommandHandler(ITranslatorRepository repository) : IRequestHandler<TranslateCommand, ToTranslateResponseDTO>
{
    public async Task<ToTranslateResponseDTO> Handle(TranslateCommand request, CancellationToken cancellationToken)
    {
        TranslatorEntity translatorEntity = new()
        {
             Guid = Guid.NewGuid().ToString(),
             Date = DateTime.Now,
             IsProcessed = false,
             TargetLanguage = request.TranslatorDTO.TargetLanguage,
             OriginalText = request.TranslatorDTO.Text
        };

        TranslatorEntity created = await repository.Create(translatorEntity);
        return new ToTranslateResponseDTO() { Guid = created.Guid };
    }
}
