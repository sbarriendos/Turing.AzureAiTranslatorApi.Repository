using Application.Abstractions;
using Application.DTOs;
using Domain.Entities;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace Infraestructure.Repositories;
public class TranslatorRepository(TranslatorDbContext db) : ITranslatorRepository
{
    public async Task<TranslatorEntity> Create(TranslatorEntity toCreate)
    {
        db.Translators.Add(toCreate);
        await db.SaveChangesAsync();
        return toCreate;
    }
    public async Task<TranslatorEntity?> Get(string guid)
    {
        return await db.Translators.FirstOrDefaultAsync(t => t.Guid == guid);
    }
}
