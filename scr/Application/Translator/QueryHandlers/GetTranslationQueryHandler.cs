using Application.Abstractions;
using Application.DTOs;
using Application.Posts.Queries;
using Domain.Entities;
using Domain.Models;
using MediatR;

namespace Application.Posts.QueryHandlers;
internal class GetTranslationQueryHandler(ITranslationRepository repository) : IRequestHandler<GetTranslationQuery, TranslationDTO>
{
    public async Task<TranslationDTO> Handle(GetTranslationQuery request, CancellationToken cancellationToken)
    {
        TranslationEntity translatorEntity = await repository.Get(request.Guid) ?? throw new NullReferenceException($"Translation {request.Guid} not found");

        TranslationDTO translationDTO = new()
        {
            TargetLanguage = translatorEntity.TargetLanguage,
            SourceLanguage = translatorEntity.SourceLanguage,
            TranslatedText = translatorEntity.TranslatedText
        };

        return translationDTO;
    }
}
