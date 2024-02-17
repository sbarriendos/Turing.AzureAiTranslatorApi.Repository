using Application.DTOs;
using Domain.Entities;
using Domain.Models;

namespace Application.Abstractions;
public interface ITranslatorRepository
{
    Task<TranslatorEntity> Create(TranslatorEntity toCreate);
    Task<TranslatorEntity?> Get(string guid);
}
