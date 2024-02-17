using Application.DTOs;
using Domain.Entities;
using Domain.Models;

namespace Application.Abstractions;
public interface ITranslationRepository
{
    Task<TranslationEntity> Create(TranslationEntity toCreate);
    Task<TranslationEntity?> Get(string guid);
    Task<TranslationEntity?> Update(TranslationEntity toUpdate);
}
