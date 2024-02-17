using Application.DTOs;
using Domain.Entities;

namespace Application.Abstractions;
public interface ICloudTranslatorService
{
    Task<AzureAiTranslationEntity> TranslateAsync(string targetLanguage, string inputText);
}