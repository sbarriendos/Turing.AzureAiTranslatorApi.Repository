using Application.Abstractions;
using Application.DTOs;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static System.Formats.Asn1.AsnWriter;

namespace Application.Translator;
public class BackgroundTranslator(ILogger<BackgroundTranslator> _log, IServiceScopeFactory _serviceScopeFactory, ICloudTranslatorRepository cloudTranslator)
{
    public async Task TranslateAsync(TranslationEntity translationEntity)
    {
        using IServiceScope scope = _serviceScopeFactory.CreateScope();
        ITranslationRepository repository = scope.ServiceProvider.GetRequiredService<ITranslationRepository>();

        try
        {
            AzureAiTranslationEntity translation = await cloudTranslator.TranslateAsync(translationEntity.TargetLanguage, translationEntity.OriginalText);

            translationEntity.IsProcessed = true;
            translationEntity.SourceLanguage = translation.DetectedLanguage;
            translationEntity.TranslatedText = translation.TranslatedText;
            translationEntity.Score = translation.Score;

            _log.LogInformation("Translation {guid} successfully done", translationEntity.Guid);
        }
        catch (Exception ex)
        {
            _log.LogError(ex, "Error during translation {guid}", translationEntity.Guid);

            translationEntity.IsProcessed = true;
            translationEntity.Error = $"Error during translation: {ex.Message}";
        }

        await repository.Update(translationEntity);
    }
}
