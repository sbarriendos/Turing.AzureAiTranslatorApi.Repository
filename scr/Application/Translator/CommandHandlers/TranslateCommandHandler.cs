using Application.Abstractions;
using Application.DTOs;
using Application.Translator.Commands;
using Domain.Entities;
using Domain.Models;
using MediatR;
using static System.Formats.Asn1.AsnWriter;

namespace Application.Translator.CommandHandlers;
public class TranslateCommandHandler(ITranslatorRepository repository, ICloudTranslatorService cloudTranslator) : IRequestHandler<TranslateCommand, ToTranslateResponseDTO>
{
    public async Task<ToTranslateResponseDTO> Handle(TranslateCommand request, CancellationToken cancellationToken)
    {
        AzureAiTranslationEntity translation = await cloudTranslator.TranslateAsync(request.TranslatorDTO.TargetLanguage, request.TranslatorDTO.Text);

        TranslatorEntity translatorEntity = new()
        {
             Guid = Guid.NewGuid().ToString(),
             Date = DateTime.Now,
             IsProcessed = false,
             TargetLanguage = request.TranslatorDTO.TargetLanguage,
             OriginalText = request.TranslatorDTO.Text,

            SourceLanguage = translation.DetectedLanguage,
            TranslatedText = translation.TranslatedText,
            Score = translation.Score
            //Error = translation.Error
        };

        TranslatorEntity created = await repository.Create(translatorEntity);
        return new ToTranslateResponseDTO() { Guid = created.Guid };
    }
}