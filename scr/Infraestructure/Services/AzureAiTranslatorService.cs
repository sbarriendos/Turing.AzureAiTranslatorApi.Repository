using Application.Abstractions;
using Application.DTOs;
using Azure;
using Azure.AI.Translation.Text;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Services;
public class AzureAiTranslatorService(ILogger<AzureAiTranslatorService> _log, TextTranslationClient _client) : ICloudTranslatorService
{
    public async Task<AzureAiTranslationEntity> TranslateAsync(string targetLanguage, string inputText)
    {
        Response<IReadOnlyList<TranslatedTextItem>> response = await _client.TranslateAsync(targetLanguage, inputText);
        IReadOnlyList<TranslatedTextItem> translations = response.Value;
        TranslatedTextItem translation = translations[0];

        string detectedLanguage = translation?.DetectedLanguage?.Language ?? throw new NullReferenceException("detectedLanguage");
        float score = translation?.DetectedLanguage?.Score ?? throw new NullReferenceException("score");
        _log.LogInformation("Detected languages of the input text: {detectedLanguage} with score: {score}", detectedLanguage, score);

        string translatedLenguage = translation?.Translations?[0].To ?? throw new NullReferenceException("translatedLenguage");
        string translatedText = translation?.Translations?[0].Text ?? throw new NullReferenceException("translatedText");
        _log.LogInformation("Text was translated to: '{translatedLenguage}' and the result is: '{translatedText}'", translatedLenguage, translatedText);

        AzureAiTranslationEntity entity = new()
        {
            DetectedLanguage = detectedLanguage,
            Score = score,
            TranslatedLanguage = translatedLenguage,
            TranslatedText = translatedText
        };

        return entity;
    }
}
