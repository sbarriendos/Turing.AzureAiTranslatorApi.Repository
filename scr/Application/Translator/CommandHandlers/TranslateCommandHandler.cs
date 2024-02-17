using Application.Abstractions;
using Application.DTOs;
using Application.Translator.Commands;
using Domain.Entities;
using Domain.Models;
using MediatR;
using static System.Formats.Asn1.AsnWriter;

namespace Application.Translator.CommandHandlers;
public class TranslateCommandHandler(ITranslationRepository repository, BackgroundTranslator backgroundTranslator) : IRequestHandler<TranslateCommand, ToTranslateResponseDTO>
{
    public async Task<ToTranslateResponseDTO> Handle(TranslateCommand request, CancellationToken cancellationToken)
    {
        TranslationEntity translatorEntity = new()
        {
             Guid = Guid.NewGuid().ToString(),
             Date = DateTime.Now,
             IsProcessed = false,
             TargetLanguage = request.TranslatorDTO.TargetLanguage,
             OriginalText = request.TranslatorDTO.Text,
        };

        TranslationEntity created = await repository.Create(translatorEntity);

        _ = backgroundTranslator.TranslateAsync(created);

        return new ToTranslateResponseDTO() { Guid = created.Guid };
    }
}