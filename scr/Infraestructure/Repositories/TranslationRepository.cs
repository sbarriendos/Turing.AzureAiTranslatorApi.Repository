using Application.Abstractions;
using Application.DTOs;
using Domain.Entities;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace Infraestructure.Repositories;
public class TranslationRepository(TranslationDbContext db) : ITranslationRepository
{
    public async Task<TranslationEntity> Create(TranslationEntity toCreate)
    {
        db.Translations.Add(toCreate);
        await db.SaveChangesAsync();
        return toCreate;
    }
    public async Task<TranslationEntity?> Get(string guid)
    {
        return await db.Translations.FirstOrDefaultAsync(t => t.Guid == guid);
    }
    public async Task<TranslationEntity?> Update(TranslationEntity toUpdate)
    {
        db.Translations.Update(toUpdate);

        await db.SaveChangesAsync();
        return toUpdate;
    }
}
