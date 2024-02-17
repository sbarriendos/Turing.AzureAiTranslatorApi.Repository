using Application.DTOs;
using Domain.Entities;

namespace Application.Abstractions;
public interface ICloudTranslatorRepository
{
    Task<AzureAiTranslationEntity> TranslateAsync(string targetLanguage, string inputText);
}